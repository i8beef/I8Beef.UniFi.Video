using System;
using System.Collections.Generic;
using System.Text;

namespace I8Beef.UniFi.Video.Protocol.Bootstrap
{
    /// <summary>
    /// Cycle type.
    /// </summary>
    public enum CycleType
    {
        /// <summary>
        /// Cameras in a sub view cycle when motion is detected.
        /// </summary>
        Motion,

        /// <summary>
        /// Cameras in a sub view cycle after a specified time interval.
        /// </summary>
        Time
    }
}
