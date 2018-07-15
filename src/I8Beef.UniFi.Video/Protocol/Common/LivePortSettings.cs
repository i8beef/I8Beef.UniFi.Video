namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// Live port settings.
    /// </summary>
    public class LivePortSettings
    {
        /// <summary>
        /// Is RTMP enabled?
        /// </summary>
        public bool RtmpEnabled { get; set; }

        /// <summary>
        /// Rtmp port.
        /// </summary>
        public int RtmpPort { get; set; }

        /// <summary>
        /// Is RTMPS enabled?
        /// </summary>
        public bool RtmpsEnabled { get; set; }

        /// <summary>
        /// RTMPS port.
        /// </summary>
        public int RtmpsPort { get; set; }

        /// <summary>
        /// Is RTSP enabled?
        /// </summary>
        public bool RtspEnabled { get; set; }

        /// <summary>
        /// RTSP port.
        /// </summary>
        public int RtspPort { get; set; }
    }
}