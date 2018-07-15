using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace I8Beef.UniFi.Video.Protocol.Bootstrap
{
    /// <summary>
    /// Live view.
    /// </summary>
    public class LiveView
    {
        /// <summary>
        /// Name of the live view.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sub views within this live view.
        /// </summary>
        public IList<SubView> SubViews { get; set; }

        /// <summary>
        /// User id that created this live view.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
