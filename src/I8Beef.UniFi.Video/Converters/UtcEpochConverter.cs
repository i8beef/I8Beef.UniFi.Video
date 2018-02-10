using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace I8Beef.UniFi.Video.Converters
{
    /// <summary>
    /// JSON.NET converter for date times to epoch
    /// </summary>
    public class UtcEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value).RemoveMilliseconds().ToUniversalTime().ToUnixTimestamp().ToString());
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds((long)reader.Value / 1000d);
        }
    }
}
