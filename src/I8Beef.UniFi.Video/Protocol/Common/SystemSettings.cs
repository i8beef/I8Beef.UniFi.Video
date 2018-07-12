namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// System settings.
    /// </summary>
    public class SystemSettings
    {
        /// <summary>
        /// Camera password.
        /// </summary>
        public string CameraPassword { get; set; }

        /// <summary>
        /// Default language.
        /// </summary>
        public string DefaultLanguage { get; set; }

        /// <summary>
        /// Disable auto camera update.
        /// </summary>
        public bool DisableAutoCameraUpdate { get; set; }

        /// <summary>
        /// Disable discover.
        /// </summary>
        public bool DisableDiscover { get; set; }

        /// <summary>
        /// Disable stats gathering.
        /// </summary>
        public bool DisableStatsGathering { get; set; }

        /// <summary>
        /// Disable update check.
        /// </summary>
        public bool DisableUpdateCheck { get; set; }

        /// <summary>
        /// Google maps api key.
        /// </summary>
        public string GoogleMapsApiKey { get; set; }

        /// <summary>
        /// Time zone.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Use UPNP?
        /// </summary>
        public bool UseUpnp { get; set; }
    }
}