using System;
using System.Collections.Generic;
using I8Beef.UniFi.Video.Converters;
using I8Beef.UniFi.Video.Protocol.Common;
using Newtonsoft.Json;

namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Camera.
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// UUID.
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Uptime origination date.
        /// </summary>
        [JsonConverter(typeof(UtcEpochConverter))]
        public DateTime Uptime { get; set; }

        /// <summary>
        /// Firmware version.
        /// </summary>
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// Firmware build.
        /// </summary>
        public string FirmwareBuild { get; set; }

        /// <summary>
        /// Protocol version.
        /// </summary>
        public int ProtocolVersion { get; set; }

        /// <summary>
        /// System info.
        /// </summary>
        public SystemInfo SystemInfo { get; set; }

        /// <summary>
        /// MAC address.
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// Indicates if managed.
        /// </summary>
        public bool Managed { get; set; }

        /// <summary>
        /// Indicates if managed by another NVR.
        /// </summary>
        public bool ManagedByOthers { get; set; }

        /// <summary>
        /// Indicates if provisioned.
        /// </summary>
        public bool Provisioned { get; set; }

        /// <summary>
        /// Indicates if a request has been made to break management relationship.
        /// </summary>
        public bool UnmanagementRequested { get; set; }

        /// <summary>
        /// Last seen date.
        /// </summary>
        [JsonConverter(typeof(UtcEpochConverter))]
        public DateTime LastSeen { get; set; }

        /// <summary>
        /// Internal host.
        /// </summary>
        public string InternalHost { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Disconnect reason.
        /// </summary>
        public string DisconnectReason { get; set; }

        /// <summary>
        /// Platform.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Management token.
        /// </summary>
        /// <remarks>
        /// Object structure is not defined for this property.
        /// </remarks>
        public object ManagementToken { get; set; }

        /// <summary>
        /// Controller host address.
        /// </summary>
        public string ControllerHostAddress { get; set; }

        /// <summary>
        /// Controller host port.
        /// </summary>
        public int ControllerHostPort { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Last recording id.
        /// </summary>
        public string LastRecordingId { get; set; }

        /// <summary>
        /// Last recording start time.
        /// </summary>
        [JsonConverter(typeof(UtcEpochConverter))]
        public DateTime LastRecordingStartTime { get; set; }

        /// <summary>
        /// Device settings.
        /// </summary>
        public DeviceSettings DeviceSettings { get; set; }

        /// <summary>
        /// Indicates if suggested video settings are enabled.
        /// </summary>
        public bool EnableSuggestedVideoSettings { get; set; }

        /// <summary>
        /// Mic volume.
        /// </summary>
        public int MicVolume { get; set; }

        /// <summary>
        /// Audio bitrate.
        /// </summary>
        public int AudioBitRate { get; set; }

        /// <summary>
        /// Channels.
        /// </summary>
        public List<Channel> Channels { get; set; }

        /// <summary>
        /// Image settings.
        /// </summary>
        public IspSettings IspSettings { get; set; }

        /// <summary>
        /// In screen display settings.
        /// </summary>
        public OsdSettings OsdSettings { get; set; }

        /// <summary>
        /// Camera recording settings.
        /// </summary>
        public CameraRecordingSettings RecordingSettings { get; set; }

        /// <summary>
        /// Schedule Id.
        /// </summary>
        public string ScheduleId { get; set; }

        /// <summary>
        /// Motion detection zones.
        /// </summary>
        public List<Zone> Zones { get; set; }

        /// <summary>
        /// Map settings.
        /// </summary>
        public MapSettings MapSettings { get; set; }

        /// <summary>
        /// Network status.
        /// </summary>
        public NetworkStatus NetworkStatus { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public CameraStatus Status { get; set; }

        /// <summary>
        /// Auth token.
        /// </summary>
        public IDictionary<string, string> AuthToken { get; set; }

        /// <summary>
        /// Cert signature.
        /// </summary>
        public string CertSignature { get; set; }

        /// <summary>
        /// Has default credentials.
        /// </summary>
        public bool HasDefaultCredentials { get; set; }

        /// <summary>
        /// Analytics settings.
        /// </summary>
        public AnalyticsSettings AnalyticsSettings { get; set; }

        /// <summary>
        /// Indicates if status LED is enabled.
        /// </summary>
        public bool EnableStatusLed { get; set; }

        /// <summary>
        /// Indicates if LED face is always on when managed.
        /// </summary>
        public bool LedFaceAlwaysOnWhenManaged { get; set; }

        /// <summary>
        /// Indicates if speaker is enabled.
        /// </summary>
        public bool EnableSpeaker { get; set; }

        /// <summary>
        /// Indicates if system sounds are enabled.
        /// </summary>
        public bool SystemSoundsEnabled { get; set; }

        /// <summary>
        /// Speaker volume.
        /// </summary>
        public int SpeakerVolume { get; set; }

        /// <summary>
        /// Indicates if this camera has been removed.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Auth status.
        /// </summary>
        public string AuthStatus { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
