using System;
using System.Collections.Generic;
using I8Beef.UniFi.Video.Converters;
using Newtonsoft.Json;

namespace I8Beef.UniFi.Video.Protocol.Recording
{
    /// <summary>
    /// Recording.
    /// </summary>
    public class Recording
    {
        /// <summary>
        /// Event type.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Start time.
        /// </summary>
        [JsonConverter(typeof(UtcEpochConverter))]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time.
        /// </summary>
        [JsonConverter(typeof(UtcEpochConverter))]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Cameras.
        /// </summary>
        public IList<string> Cameras { get; set; }

        /// <summary>
        /// Locked.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// In progress.
        /// </summary>
        public bool InProgress { get; set; }

        /// <summary>
        /// Marked for deletion.
        /// </summary>
        public bool MarkedForDeletion { get; set; }

        /// <summary>
        /// Recording metadata.
        /// </summary>
        public RecordingMetadata Meta { get; set; }

        /// <summary>
        /// Recording Id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
