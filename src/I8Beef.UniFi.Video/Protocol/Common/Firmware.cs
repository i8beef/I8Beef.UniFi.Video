using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// Firmware.
    /// </summary>
    public class Firmware
    {
        /// <summary>
        /// Firmware code.
        /// </summary>
        public string FirmwareCode { get; set; }

        /// <summary>
        /// MD5 hash.
        /// </summary>
        public string Md5 { get; set; }

        /// <summary>
        /// Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Platform.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Protocol version.
        /// </summary>
        public int ProtocolVersion { get; set; }

        /// <summary>
        /// Revision.
        /// </summary>
        public dynamic Revision { get; set; }

        /// <summary>
        /// Source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Version in format "vX.Y.Z"
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
