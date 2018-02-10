namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Analytics settings.
    /// </summary>
    public class AnalyticsSettings
    {
        /// <summary>
        /// Enable sound alert.
        /// </summary>
        public bool EnableSoundAlert { get; set; }

        /// <summary>
        /// Sound alert volume.
        /// </summary>
        public int SoundAlertVolume { get; set; }

        /// <summary>
        /// Minimum motion seconds.
        /// </summary>
        public int MinimumMotionSecs { get; set; }

        /// <summary>
        /// End motion after seconds.
        /// </summary>
        public int EndMotionAfterSecs { get; set; }
    }
}
