using System.Collections.Generic;

namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Status.
    /// </summary>
    public class CameraStatus
    {
        /// <summary>
        /// Recording status.
        /// </summary>
        public IDictionary<int, RecordingStatus> RecordingStatus { get; set; }

        /// <summary>
        /// Scheduled action.
        /// </summary>
        /// <remarks>
        /// Object structure is not defined for this property.
        /// </remarks>
        public object ScheduledAction { get; set; }

        /// <summary>
        /// Remote host.
        /// </summary>
        public string RemoteHost { get; set; }

        /// <summary>
        /// Remote port.
        /// </summary>
        public long RemotePort { get; set; }
    }
}
