namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// Recording settings.
    /// </summary>
    public class RecordingSettings
    {
        /// <summary>
        /// MB of space to retain.
        /// </summary>
        public long MbToRetain { get; set; }

        /// <summary>
        /// Recording storage path.
        /// </summary>
        public string StoragePath { get; set; }

        /// <summary>
        /// Temp storage path.
        /// </summary>
        public string TempStoragePath { get; set; }

        /// <summary>
        /// Time to retain.
        /// </summary>
        public long TimeToRetain { get; set; }
    }
}