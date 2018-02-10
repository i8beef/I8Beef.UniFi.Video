using System.Collections.Generic;

namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Channel.
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Is RTSP enabled.
        /// </summary>
        public bool IsRtspEnabled { get; set; }

        /// <summary>
        /// RTSP URLs.
        /// </summary>
        public List<string> RtspUris { get; set; }

        /// <summary>
        /// Is RTMP enabled.
        /// </summary>
        public bool IsRtmpEnabled { get; set; }

        /// <summary>
        /// RTMP URLs.
        /// </summary>
        public List<string> RtmpUris { get; set; }

        /// <summary>
        /// Is RTMPS enabled.
        /// </summary>
        public bool IsRtmpsEnabled { get; set; }

        /// <summary>
        /// RTMPS URLs.
        /// </summary>
        public List<string> RtmpsUris { get; set; }

        /// <summary>
        /// Width.
        /// </summary>
        public long Width { get; set; }

        /// <summary>
        /// Height.
        /// </summary>
        public long Height { get; set; }

        /// <summary>
        /// Frames per second.
        /// </summary>
        public long Fps { get; set; }

        /// <summary>
        /// Bitrate.
        /// </summary>
        public long Bitrate { get; set; }

        /// <summary>
        /// Minimum bitrate.
        /// </summary>
        public long MinBitrate { get; set; }

        /// <summary>
        /// Maximum bitrate.
        /// </summary>
        public long MaxBitrate { get; set; }

        /// <summary>
        /// FPS values.
        /// </summary>
        public List<long> FpsValues { get; set; }

        /// <summary>
        /// IDR interval.
        /// </summary>
        public long IdrInterval { get; set; }
    }
}
