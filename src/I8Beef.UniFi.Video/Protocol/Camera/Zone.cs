using System.Collections.Generic;
using I8Beef.UniFi.Video.Protocol.Common;
using Newtonsoft.Json;

namespace I8Beef.UniFi.Video.Protocol.Camera
{
    /// <summary>
    /// Motion capture Zone.
    /// </summary>
    public class Zone
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sensitivity.
        /// </summary>
        public int Sensitivity { get; set; }

        /// <summary>
        /// Bitmap.
        /// </summary>
        /// <remarks>
        /// Object structure is not defined for this property.
        /// </remarks>
        public object Bitmap { get; set; }

        /// <summary>
        /// Coordinates.
        /// </summary>
        public List<Coordinate> Coordinates { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
