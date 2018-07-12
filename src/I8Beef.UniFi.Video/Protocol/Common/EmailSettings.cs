namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// Email settings.  Note, will only show in settings when not connected to a ubnt account.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Is smtp / email server enabled?
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// SMTP host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// SMTP port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Public host.
        /// </summary>
        public string PublicHost { get; set; }

        /// <summary>
        /// Does the SMTP server require authentication?
        /// </summary>
        public bool RequiresAuthentication { get; set; }

        /// <summary>
        /// Use SSL when connecting to the SMTP server?
        /// </summary>
        public bool UseSsl { get; set; }
    }
}