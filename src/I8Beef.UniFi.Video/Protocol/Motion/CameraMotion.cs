using System.Collections.Generic;

namespace I8Beef.UniFi.Video.Protocol.Motion
{
    /// <summary>
    /// Camera motion event.
    /// </summary>
    public class CameraMotion
    {
        /// <summary>
        /// Camera ID.
        /// </summary>
        public string CameraId { get; set; }

        /// <summary>
        /// Motion events.
        /// </summary>
        public IList<MotionEvent> Data { get; set; }
    }
}
