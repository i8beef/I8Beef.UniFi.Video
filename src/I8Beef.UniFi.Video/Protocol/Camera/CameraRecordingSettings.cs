namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Camera recording settings.
    /// </summary>
    public class CameraRecordingSettings
    {
        /// <summary>
        /// indicates if motion recording is enabled.
        /// </summary>
        public bool MotionRecordEnabled { get; set; }

        /// <summary>
        /// Indicates if full time recording is enabled.
        /// </summary>
        public bool FullTimeRecordEnabled { get; set; }

        /// <summary>
        /// Channel.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Seconds to record before event.
        /// </summary>
        public long PrePaddingSecs { get; set; }

        /// <summary>
        /// Seconds to record after event.
        /// </summary>
        public long PostPaddingSecs { get; set; }

        /// <summary>
        /// Storage path.
        /// </summary>
        /// <remarks>
        /// Object structure is not defined for this property.
        /// </remarks>
        public object StoragePath { get; set; }
    }
}
