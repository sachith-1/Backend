﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using CovidSafe.DAL.Helpers;
using CovidSafe.DAL.Repositories.Cosmos.Client;
using CovidSafe.DAL.Repositories.Cosmos.Records;
using CovidSafe.Entities.Geospatial;
using CovidSafe.Entities.Protos;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.Cosmos.Spatial;

namespace CovidSafe.DAL.Repositories.Cosmos
{
    /// <summary>
    /// CosmosDB implementation of <see cref="IMatchMessageRepository"/>
    /// </summary>
    public class CosmosMatchMessageRepository : CosmosRepository, IMatchMessageRepository
    {
        /// <summary>
        /// Precision of regions that are used for keys.
        /// </summary>
        private int RegionPrecision = 4;
        /// <summary>
        /// Search extension size
        /// </summary>
        private int RegionsExtension = 1;

        /// <summary>
        /// Creates a new <see cref="CosmosMatchMessageRepository"/> instance
        /// </summary>
        /// <param name="dbContext"><see cref="CosmosContext"/> instance</param>
        public CosmosMatchMessageRepository(CosmosContext dbContext) : base(dbContext)
        {
            // Create container reference
            this.Container = this.Context.GetContainer(
                this.Context.SchemaOptions.MessageContainerName
            );
        }

        /// <inheritdoc/>
        public async Task<MatchMessage> GetAsync(string messageId, CancellationToken cancellationToken = default)
        {
            // Create LINQ query
            var queryable = this.Container
                .GetItemLinqQueryable<MatchMessageRecord>();

            // Execute query
            var iterator = queryable
                .Where(r =>
                    r.Id == messageId
                    && r.Version == MatchMessageRecord.CURRENT_RECORD_VERSION
                ).ToFeedIterator();

            List<MatchMessage> results = new List<MatchMessage>();

            while (iterator.HasMoreResults)
            {
                foreach (MatchMessageRecord record in await iterator.ReadNextAsync())
                {
                    results.Add(record.Value);
                }
            }

            return results.FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MessageInfo>> GetLatestAsync(Region region, long lastTimestamp, CancellationToken cancellationToken = default)
        {
            // Get boundaries for provided region
            Point regionPoint = new Point(region.LongitudePrefix, region.LatitudePrefix);

            // Create LINQ query
            var queryable = this.Container
                .GetItemLinqQueryable<MatchMessageRecord>();

            ISet<string> regionIds = new HashSet<string>(
                RegionHelper.GetConnectedRegions(region, this.RegionsExtension, this.RegionPrecision).Select(
                    r => RegionHelper.GetRegionIdentifier(r)));

            // Execute query
            var iterator = queryable
                .Where(r =>
                    r.Timestamp > lastTimestamp
                    && regionIds.Contains(r.RegionId)
                    && r.Version == MatchMessageRecord.CURRENT_RECORD_VERSION
                ).ToFeedIterator();

            List<MessageInfo> results = new List<MessageInfo>();

            while(iterator.HasMoreResults)
            {
                foreach(MatchMessageRecord record in await iterator.ReadNextAsync())
                {
                    results.Add(new MessageInfo
                    {
                        MessageId = record.Id,
                        MessageTimestamp = record.Timestamp
                    });
                }
            }

            return results;
        }

        /// <inheritdoc/>
        public async Task<long> GetLatestRegionSizeAsync(Region region, long lastTimestamp, CancellationToken cancellationToken = default)
        {
            // Get boundaries for provided region
            Point regionPoint = new Point(region.LongitudePrefix, region.LatitudePrefix);

            // Create LINQ query
            var queryable = this.Container
                .GetItemLinqQueryable<MatchMessageRecord>();

            ISet<string> regionIds = new HashSet<string>(
                RegionHelper.GetConnectedRegions(region, this.RegionsExtension, this.RegionPrecision).Select(
                    r => RegionHelper.GetRegionIdentifier(r)));

            // Execute query
            var iterator = queryable
                .Where(r =>
                    r.Timestamp > lastTimestamp
                    && regionIds.Contains(r.RegionId)
                    && r.Version == MatchMessageRecord.CURRENT_RECORD_VERSION
                ).ToFeedIterator();

            long size = 0;

            while (iterator.HasMoreResults)
            {
                foreach (MatchMessageRecord record in await iterator.ReadNextAsync())
                {
                    size += record.Size;
                }
            }

            return size;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MatchMessage>> GetRangeAsync(IEnumerable<string> ids, CancellationToken cancellationToken)
        {
            // Create LINQ query
            var queryable = this.Container
                .GetItemLinqQueryable<MatchMessageRecord>();

            // Execute query
            var iterator = queryable
                .Where(r =>
                    ids.Contains(r.Id)
                    && r.Version == MatchMessageRecord.CURRENT_RECORD_VERSION
                ).ToFeedIterator();

            List<MatchMessage> results = new List<MatchMessage>();

            while (iterator.HasMoreResults)
            {
                foreach (MatchMessageRecord record in await iterator.ReadNextAsync())
                {
                    results.Add(record.Value);
                }
            }

            return results;
        }

        /// <inheritdoc/>
        public async Task<string> InsertAsync(Region region, MatchMessage message, CancellationToken cancellationToken = default)
        {
            if(region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }
            if(message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if(region.Precision != this.RegionPrecision)
            {
                throw new InvalidDataException($"Precision {region.Precision} is not supported right now. Please use {this.RegionPrecision}.");
            }

            region = RegionHelper.AdjustToPrecision(region);

            // Get allowed region boundary
            RegionBoundary boundary = RegionHelper.GetRegionBoundary(region);

            var record = new MatchMessageRecord(message)
            {
                Id = Guid.NewGuid().ToString(),
                RegionBoundary = new RegionBoundaryProperty(boundary),
                Region = new RegionProperty(region),
                RegionId = RegionHelper.GetRegionIdentifier(region),
                Size = PayloadSizeHelper.GetSize(message),
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Version = MatchMessageRecord.CURRENT_RECORD_VERSION
            };

            ItemResponse<MatchMessageRecord> response = await this.Container
                .CreateItemAsync<MatchMessageRecord>(
                    record,
                    new PartitionKey(record.RegionId),
                    cancellationToken: cancellationToken
                );

            return response.Resource.Id;
        }
    }
}
