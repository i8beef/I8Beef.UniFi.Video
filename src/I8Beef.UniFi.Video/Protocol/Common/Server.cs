using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// Server.
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Alert settings.
        /// </summary>
        public AlertSettings AlertSettings { get; set; }

        /// <summary>
        /// Cloud settings.
        /// </summary>
        public CloudSettings CloudSettings { get; set; }

        /// <summary>
        /// Email settings.
        /// </summary>
        public EmailSettings EmailSettings { get; set; }

        /// <summary>
        /// Ems file stats.
        /// </summary>
        public dynamic EmsFileStats { get; set; }

        /// <summary>
        /// Firmware build.
        /// </summary>
        public string FirmwareBuild { get; set; }

        /// <summary>
        /// Firmware version.
        /// </summary>
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// Host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Live port settings.
        /// </summary>
        public LivePortSettings LivePortSettings { get; set; }

        /// <summary>
        /// NVR model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// NVR name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Protocol version.
        /// </summary>
        public dynamic ProtocolVersion { get; set; }

        /// <summary>
        /// Recording settings.
        /// </summary>
        public RecordingSettings RecordingSettings { get; set; }

        /// <summary>
        /// System info.
        /// </summary>
        public SystemInfo SystemInfo { get; set; }

        /// <summary>
        /// System settings.
        /// </summary>
        public SystemSettings SystemSettings { get; set; }

        /// <summary>
        /// NVR uptime.
        /// </summary>
        public long Uptime { get; set; }

        /// <summary>
        /// UUID.
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
