using System;
using I8Beef.UniFi.Video.Converters;
using Newtonsoft.Json;

namespace I8Beef.UniFi.Video.Protocol.Motion
{
    /// <summary>
    /// Motion event.
    /// </summary>
    public class MotionEvent
    {
        /// <summary>
        /// Sensitivity score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Timestamp for event.
        /// </summary>
        [JsonConverter(typeof(UtcEpochConverter))]
        public DateTime Timestamp { get; set; }
    }
}
