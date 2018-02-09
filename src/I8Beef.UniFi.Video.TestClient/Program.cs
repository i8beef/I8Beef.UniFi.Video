using System;
using System.Threading.Tasks;

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
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Async Main.
        /// </summary>
        /// <param name="args">Arguments.</param>
        public static async Task MainAsync(string[] args)
        {
            var host = "";
            var username = "";
            var password = "";

            using (var client = new Client(host, username, password, true))
            {
                await client.AuthorizeAsync();
                var bootstrap = await client.BootstrapAsync();
                var cameras = await client.CamerasAsync();

                foreach (var cameraId in cameras.Keys)
                {
                    var newCameraInfo = await client.CameraAsync(cameraId);
                }


                Console.ReadKey();
            }
        }
    }
}
