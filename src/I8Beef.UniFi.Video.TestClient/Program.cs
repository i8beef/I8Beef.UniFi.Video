using I8Beef.UniFi.Video.Protocol.Recording;
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
                var cameras = await client.CameraAsync();
                var cameraIds = cameras.Select(x => x.Id);

                var waitSeconds = 1;
                while (true)
                {
                    var now = DateTime.Now;

                    #region Recording based detection

                    // Get all recordings since the last run
                    var recordings = await client.RecordingAsync(now.AddSeconds(-60), now, cameraIds, new List<RecordingEventType> { RecordingEventType.MotionRecording });

                    // Determine if there are any motion alerts in the time span with a score over motionTheshold
                    var inProgressRecordings = recordings.Where(x => x.InProgress);
                    foreach (var recording in inProgressRecordings)
                    {
                        Debug.WriteLine($"RECORDING: Motion detected on camera {recording.Cameras[0]}");
                    }

                    #endregion

                    #region Motion event based detection

                    // Get motion alerts since last run
                    var motionAlerts = await client.MotionAlertsAsync(now.AddSeconds(-60), now, 2, cameraIds);

                    foreach (var camera in cameras)
                    {
                        // Determine motion threshold from current camera settings
                        int motionThreshold = 50;
                        if (camera.Zones.Count() > 0)
                            motionThreshold = camera.Zones[0].Sensitivity;

                        int motionSecondsCutoff = camera.AnalyticsSettings.EndMotionAfterSecs;

                        // Determine if there are any motion alerts with a score over motionTheshold
                        var motionAlertsForCamera = motionAlerts.FirstOrDefault(x => x.CameraId == camera.Id);
                        if (motionAlertsForCamera != null && motionAlertsForCamera.Data.Any(x =>
                             x.Score >= motionThreshold &&
                             now.RemoveMilliseconds().ToUniversalTime().Subtract(x.Timestamp).Seconds < motionSecondsCutoff))
                        {
                            Debug.WriteLine($"EVENT: Motion detected on camera {camera.Id}");
                        }
                    }

                    #endregion

                    // Wait on second
                    await Task.Delay(waitSeconds * 1000);
                }

                Console.ReadKey();
            }
        }
    }
}
