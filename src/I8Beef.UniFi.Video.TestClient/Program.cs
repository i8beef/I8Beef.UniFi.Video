using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

                var waitSeconds = 1;
                var lastRun = DateTime.Now;
                while (true)
                {
                    var now = DateTime.Now;

                    #region Recording based detection

                    // Get all recordings since the last run
                    dynamic recordings = await client.RecordingAsync(cameras.Keys.ToList(), new List<string> { "motionRecording" }, now.AddSeconds(-60), now);

                    // Determine if there are any motion alerts in the time span with a score over motionTheshold
                    var inProgressRecordings = ((IEnumerable<dynamic>)recordings.data).Where(x => x.inProgress == true);
                    foreach (var recording in inProgressRecordings)
                    {
                        Debug.WriteLine($"RECORDING: Motion detected on camera {recording.cameras[0]}");
                    }

                    #endregion

                    foreach (var cameraId in cameras.Keys)
                    {
                        #region Motion event based detection

                        // Determine motion threshold from current camera settings
                        int motionThreshold = 50;
                        if (cameras[cameraId].zones.Count > 0)
                            motionThreshold = cameras[cameraId].zones[0].sensitivity;

                        // Get motion alerts in the last waitForSeconds time span
                        dynamic motionAlerts = await client.MotionAlertsAsync(new List<string> { cameraId }, lastRun, now);

                        // Determine if there are any motion alerts in the time span with a score over motionTheshold
                        if (motionAlerts.data.Count > 0)
                            if (((IEnumerable<dynamic>)motionAlerts.data[0].data).Any(x => x.score > motionThreshold))
                                Debug.WriteLine($"EVENT: Motion detected on camera {cameraId}");

                        #endregion
                    }

                    lastRun = now;

                    // Wait on second
                    await Task.Delay(waitSeconds * 1000);
                }

                Console.ReadKey();
            }
        }
    }
}
