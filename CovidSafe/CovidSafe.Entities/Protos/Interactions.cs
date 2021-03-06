﻿// This file was generated by a tool; you should avoid making direct changes.
// Consider using 'partial classes' to extend these types
// Input: my.proto

#pragma warning disable CS1591, CS0612, CS3021, IDE1006
namespace CovidSafe.Entities.Protos
{

    [global::ProtoBuf.ProtoContract()]
    public partial class MessageListRequest : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"region")]
        public Region Region { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"last_query_time")]
        public long LastQueryTime { get; set; }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class MessageListResponse : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"message_info")]
        public global::System.Collections.Generic.List<MessageInfo> MessageInfoes { get; } = new global::System.Collections.Generic.List<MessageInfo>();

        [global::ProtoBuf.ProtoMember(2, Name = @"max_response_timestamp")]
        public long MaxResponseTimestamp { get; set; }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class MessageRequest : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"requested_queries")]
        public global::System.Collections.Generic.List<MessageInfo> RequestedQueries { get; } = new global::System.Collections.Generic.List<MessageInfo>();

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class MatchMessage : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"bool_expression")]
        [global::System.ComponentModel.DefaultValue("")]
        public string BoolExpression { get; set; } = "";

        [global::ProtoBuf.ProtoMember(2, Name = @"area_matches")]
        public global::System.Collections.Generic.List<AreaMatch> AreaMatches { get; } = new global::System.Collections.Generic.List<AreaMatch>();

        [global::ProtoBuf.ProtoMember(3, Name = @"bluetooth_matches")]
        public global::System.Collections.Generic.List<BluetoothMatch> BluetoothMatches { get; } = new global::System.Collections.Generic.List<BluetoothMatch>();

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class AreaMatch : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"user_message")]
        [global::System.ComponentModel.DefaultValue("")]
        public string UserMessage { get; set; } = "";

        [global::ProtoBuf.ProtoMember(2, Name = @"areas")]
        public global::System.Collections.Generic.List<Area> Areas { get; } = new global::System.Collections.Generic.List<Area>();

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class SelfReportRequest : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"seeds")]
        public global::System.Collections.Generic.List<BlueToothSeed> Seeds { get; } = new global::System.Collections.Generic.List<BlueToothSeed>();

        [global::ProtoBuf.ProtoMember(2, Name = @"region")]
        public Region Region { get; set; }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class Status : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"status_code")]
        public int StatusCode { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"status_message")]
        [global::System.ComponentModel.DefaultValue("")]
        public string StatusMessage { get; set; } = "";

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class Region : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"latitude_prefix")]
        public double LatitudePrefix { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"longitude_prefix")]
        public double LongitudePrefix { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"precision")]
        public int Precision { get; set; }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class MessageInfo : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"message_id")]
        [global::System.ComponentModel.DefaultValue("")]
        public string MessageId { get; set; } = "";

        [global::ProtoBuf.ProtoMember(2, Name = @"message_timestamp")]
        public long MessageTimestamp { get; set; }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class BluetoothMatch : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"user_message")]
        [global::System.ComponentModel.DefaultValue("")]
        public string UserMessage { get; set; } = "";

        [global::ProtoBuf.ProtoMember(2, Name = @"seeds")]
        public global::System.Collections.Generic.List<BlueToothSeed> Seeds { get; } = new global::System.Collections.Generic.List<BlueToothSeed>();

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class BlueToothSeed : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"seed")]
        [global::System.ComponentModel.DefaultValue("")]
        public string Seed { get; set; } = "";

        [global::ProtoBuf.ProtoMember(2, Name = @"sequence_start_time")]
        public long SequenceStartTime { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"sequence_end_time")]
        public long SequenceEndTime { get; set; }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class Area : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"location")]
        public Location Location { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"radius_meters")]
        public float RadiusMeters { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"begin_time")]
        public long BeginTime { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"end_time")]
        public long EndTime { get; set; }

    }

    [global::ProtoBuf.ProtoContract()]
    public partial class Location : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"latitude")]
        public double Latitude { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"longitude")]
        public double Longitude { get; set; }

    }

}

#pragma warning restore CS1591, CS0612, CS3021, IDE1006