namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Network status.
    /// </summary>
    public class NetworkStatus
    {
        /// <summary>
        /// Connection state.
        /// </summary>
        public int ConnectionState { get; set; }

        /// <summary>
        /// Connection state description.
        /// </summary>
        public string ConnectionStateDescription { get; set; }

        /// <summary>
        /// ESSID.
        /// </summary>
        public object Essid { get; set; }

        /// <summary>
        /// Frequency.
        /// </summary>
        public long Frequency { get; set; }

        /// <summary>
        /// Link quality.
        /// </summary>
        public int Quality { get; set; }

        /// <summary>
        /// Link quality maximum.
        /// </summary>
        public int QualityMax { get; set; }

        /// <summary>
        /// Signal level.
        /// </summary>
        public int SignalLevel { get; set; }

        /// <summary>
        /// Link speed Mbps.
        /// </summary>
        public int LinkSpeedMbps { get; set; }

        /// <summary>
        /// IP Address.
        /// </summary>
        public string IpAddress { get; set; }
    }
}
