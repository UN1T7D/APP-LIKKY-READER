// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Lukky_Reader;
//
//    var loginModel = LoginModel.FromJson(jsonString);

namespace Lukky_Reader
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public partial class LoginModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public partial class LoginModel
    {
        public static LoginModel[] FromJson(string json) => JsonConvert.DeserializeObject<LoginModel[]>(json, Lukky_Reader.Converter.Settings);

    }

    /*public static class Serialize
    {
        public static string ToJson(this LoginModel[] self) => JsonConvert.SerializeObject(self, Lukky_Reader.Converter.Settings);
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
    }*/
}