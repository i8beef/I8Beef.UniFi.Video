using System;
using System.Collections.Generic;
using System.Text;

namespace I8Beef.UniFi.Video.Protocol.Bootstrap
{
    /// <summary>
    /// Sub view of a live view.
    /// </summary>
    public class SubView
    {
        /// <summary>
        /// Cameras.
        /// </summary>
        public IList<string> Cameras { get; set; }

        /// <summary>
        /// Channel.
        /// </summary>
        public int Channel { get; set; }

        /// <summary>
        /// Cycle interval in seconds.
        /// </summary>
        public int CycleInterval { get; set; }

        /// <summary>
        /// Cycle type.
        /// </summary>
        public CycleType CycleType { get; set; }

        /// <summary>
        /// Height of sub view within a 12x12 grid.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Is the sub view muted?
        /// </summary>
        public bool Muted { get; set; }

        /// <summary>
        /// Width of the sub view within a 12x12 grid.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Starting X coordinate of the sub view within a 12x12 grid.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Starting Y coordinate of the sub view within a 12x12 grid.
        /// </summary>
        public int Y { get; set; }
    }
}
