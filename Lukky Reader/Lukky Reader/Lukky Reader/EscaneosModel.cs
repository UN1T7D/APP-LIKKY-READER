﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Lukky_Reader;
//
//    var escaneosModel = EscaneosModel.FromJson(jsonString);

namespace Lukky_Reader
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public partial class EscaneosModel
    {
        [JsonProperty("data")]
        public Escaneos[] Escaneos { get; set; }
    }

    public partial class Escaneos
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; } //Uri

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        //id_usuario
        [JsonProperty("id_usuario")]
        public long Id_usuario { get; set; }
    }


    public partial class EscaneosModel
    {
        public static EscaneosModel FromJson(string json) => JsonConvert.DeserializeObject<EscaneosModel>(json, Lukky_Reader.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this EscaneosModel self) => JsonConvert.SerializeObject(self, Lukky_Reader.Converter.Settings);
        //public static string ToJson(this LoginModel self) => JsonConvert.SerializeObject(self, Lukky_Reader.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
