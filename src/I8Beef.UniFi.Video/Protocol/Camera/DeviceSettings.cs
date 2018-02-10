namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Device settings.
    /// </summary>
    public class DeviceSettings
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Timezone.
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Persists.
        /// </summary>
        public bool Persists { get; set; }
    }
}
