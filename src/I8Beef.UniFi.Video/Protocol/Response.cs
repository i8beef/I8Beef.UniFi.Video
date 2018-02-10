using System.Collections.Generic;

namespace I8Beef.UniFi.Video.Protocol
{
    /// <summary>
    /// Response for messages.
    /// </summary>
    /// <typeparam name="T">Type of response data.</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Data for the response.
        /// </summary>
        public IList<T> Data { get; set; }

        /// <summary>
        /// Response metadata.
        /// </summary>
        public ResponseMetadata Meta { get; set; }
    }
}
