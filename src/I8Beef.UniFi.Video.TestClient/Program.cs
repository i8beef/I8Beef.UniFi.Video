using System;

namespace I8Beef.UniFi.Video.TestClient
{
    /// <summary>
    /// Program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Arguments.</param>
        static void Main(string[] args)
        {
            var host = "replace";
            var username = "replace";
            var password = "replace";

            using (var client = new Client(host, username, password, true))
            {
                client.AuthorizeAsync().GetAwaiter().GetResult();
                var cameras = client.BootstrapAsync().GetAwaiter().GetResult();

                Console.ReadKey();
            }
        }
    }
}
