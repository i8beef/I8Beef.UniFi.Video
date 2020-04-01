using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.UniFi.Video.Protocol.Bootstrap;
using I8Beef.UniFi.Video.Protocol.Camera;
using I8Beef.UniFi.Video.Protocol.Common;
using I8Beef.UniFi.Video.Protocol.Motion;
using I8Beef.UniFi.Video.Protocol.Recording;
using I8Beef.UniFi.Video.Protocol.Stream;

namespace I8Beef.UniFi.Video
{
    /// <summary>
    /// UniFi Video Client.
    /// </summary>
    public interface IClient : IDisposable
    {
        /// <summary>
        /// Indicates if the client is currently authenticated.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Authorize with NVR.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable <see cref="Task"/>.</returns>
        Task AuthorizeAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets NVR Bootstrap information, which contains most of current state.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        Task<Bootstrap> BootstrapAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets NVR camera information for a single camera.
        /// </summary>
        /// <param name="cameraId">Camera ID to query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        Task<IEnumerable<Camera>> CameraAsync(string cameraId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets NVR motion alerts for a single camera.
        /// </summary>
        /// <param name="startTime">Start Time.</param>
        /// <param name="endTime">End Time.</param>
        /// <param name="intervalSeconds">Interval seconds (defaults: 2, minimum: 2, maximum: 30).</param>
        /// <param name="cameraIds">Camera IDs to query.</param>
        /// <param name="sortBy">Sort by (default: startTime).</param>
        /// <param name="sort">Sort asc or desc (default: asc).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        Task<IEnumerable<CameraMotion>> MotionAlertsAsync(DateTime startTime, DateTime endTime, int intervalSeconds = 2, IEnumerable<string> cameraIds = null, string sortBy = "startTime", string sort = "asc", CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets NVR recordings.
        /// </summary>
        /// <param name="startTime">Start Time.</param>
        /// <param name="endTime">End Time.</param>
        /// <param name="cameraIds">Camera IDs to query.</param>
        /// <param name="causes">Causes to query.</param>
        /// <param name="sortBy">Sort by (default: startTime).</param>
        /// <param name="sort">Sort asc or desc (default: desc).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        Task<IEnumerable<Recording>> RecordingAsync(DateTime startTime, DateTime endTime, IEnumerable<string> cameraIds = null, IEnumerable<RecordingEventType> causes = null, string sortBy = "startTime", string sort = "desc", CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets NVR recording ids.
        /// </summary>
        /// <param name="startTime">Start Time.</param>
        /// <param name="endTime">End Time.</param>
        /// <param name="cameraIds">Camera IDs to query.</param>
        /// <param name="causes">Causes to query.</param>
        /// <param name="sortBy">Sort by (default: startTime).</param>
        /// <param name="sort">Sort asc or desc (default: asc).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        Task<IEnumerable<string>> RecordingIdAsync(DateTime startTime, DateTime endTime, IEnumerable<string> cameraIds = null, IEnumerable<RecordingEventType> causes = null, string sortBy = "startTime", string sort = "asc", CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets NVR stream information for a single camera.
        /// </summary>
        /// <param name="cameraId">Camera ID to query.</param>
        /// <param name="channel">Stream channel to query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        Task<IEnumerable<StreamUrls>> StreamUrlAsync(string cameraId, int channel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets NVR record mode for a single camera.
        /// </summary>
        /// <param name="cameraId">Camera ID to query.</param>
        /// <param name="recordMode">Record mode.</param>
        /// <param name="channel">Stream channel.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task SetRecordModeAsync(string cameraId, RecordingMode recordMode, int? channel = null, CancellationToken cancellationToken = default);
    }
}