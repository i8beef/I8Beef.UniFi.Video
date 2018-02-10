using System.Collections.Generic;

namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// Camera system info.
    /// </summary>
    public class SystemInfo
    {
        /// <summary>
        /// CPU name.
        /// </summary>
        public string CpuName { get; set; }

        /// <summary>
        /// CPU load.
        /// </summary>
        public double CpuLoad { get; set; }

        /// <summary>
        /// Memory.
        /// </summary>
        public MemoryInformation Memory { get; set; }

        /// <summary>
        /// App memory.
        /// </summary>
        /// <remarks>
        /// Object structure is not defined for this property.
        /// </remarks>
        public MemoryInformation AppMemory { get; set; }

        /// <summary>
        /// NICs.
        /// </summary>
        public List<NicInformation> Nics { get; set; }

        /// <summary>
        /// Disk.
        /// </summary>
        public DiskInformation Disk { get; set; }
    }
}
