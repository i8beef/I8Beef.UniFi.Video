namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// Disk information.
    /// </summary>
    public class DiskInformation
    {
        /// <summary>
        /// Used KB.
        /// </summary>
        public long UsedKb { get; set; }

        /// <summary>
        /// Total KB.
        /// </summary>
        public long TotalKb { get; set; }

        /// <summary>
        /// Available KB.
        /// </summary>
        public long AvailKb { get; set; }

        /// <summary>
        /// Free KB.
        /// </summary>
        public long FreeKb { get; set; }

        /// <summary>
        /// Directory name.
        /// </summary>
        public string DirName { get; set; }

        /// <summary>
        /// /dev/ name.
        /// </summary>
        public string DevName { get; set; }
    }
}
