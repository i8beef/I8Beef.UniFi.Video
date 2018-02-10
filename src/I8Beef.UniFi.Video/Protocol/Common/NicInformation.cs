namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// NIC information.
    /// </summary>
    public class NicInformation
    {
        /// <summary>
        /// Description.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// MAC address.
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// IP address.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Rx BPS.
        /// </summary>
        public int RxBps { get; set; }

        /// <summary>
        /// Tx BPS.
        /// </summary>
        public int TxBps { get; set; }
    }
}
