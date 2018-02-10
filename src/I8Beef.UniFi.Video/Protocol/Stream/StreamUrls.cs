namespace I8Beef.UniFi.Video.Protocol.Stream
{
    /// <summary>
    /// Stream URLs.
    /// </summary>
    public class StreamUrls
    {
        /// <summary>
        /// RTMP path.
        /// </summary>
        public string RtmpPath { get; set; }

        /// <summary>
        /// WebSocket path.
        /// </summary>
        public string WsPath { get; set; }

        /// <summary>
        /// Secure WebSocket path.
        /// </summary>
        public string WssPath { get; set; }

        /// <summary>
        /// Stream name.
        /// </summary>
        public string StreamName { get; set; }
    }
}
