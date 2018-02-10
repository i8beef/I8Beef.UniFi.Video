namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Recording status.
    /// </summary>
    public class RecordingStatus
    {
        /// <summary>
        /// Indicates if motion recoridng is enabled.
        /// </summary>
        public bool MotionRecordingEnabled { get; set; }

        /// <summary>
        /// Indicates if full time recoridng is enabled.
        /// </summary>
        public bool FullTimeRecordingEnabled { get; set; }
    }
}
