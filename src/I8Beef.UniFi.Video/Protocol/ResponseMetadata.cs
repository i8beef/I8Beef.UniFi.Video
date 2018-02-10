namespace I8Beef.UniFi.Video.Protocol
{
    /// <summary>
    /// Response metadata.
    /// </summary>
    public class ResponseMetadata
    {
        /// <summary>
        /// Total data item cont.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Filtered data item count.
        /// </summary>
        public int FilteredCount { get; set; }
    }
}
