using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace I8Beef.UniFi.Video.Protocol.Common
{
    /// <summary>
    /// Map.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Google map type.
        /// </summary>
        public string GoogleMapType { get; set; }

        /// <summary>
        /// Latitude.
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        public double Lng { get; set; }

        /// <summary>
        /// Map type.
        /// </summary>
        public MapType MapType { get; set; }

        /// <summary>
        /// Map name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Map tilt.  Used for Google maps.
        /// </summary>
        public int Tilt { get; set; }

        /// <summary>
        /// Map zoom.  Used for Google maps.
        /// </summary>
        public int Zoom { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
