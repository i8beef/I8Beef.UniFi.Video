namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// On screen display settings.
    /// </summary>
    public class OsdSettings
    {
        /// <summary>
        /// Tag/
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Indicates if the message is overridden.
        /// </summary>
        public bool OverrideMessage { get; set; }

        /// <summary>
        /// Indicates if date display is enabled.
        /// </summary>
        public long EnableDate { get; set; }

        /// <summary>
        /// Indicates of logo is enabled.
        /// </summary>
        public long EnableLogo { get; set; }
    }
}
