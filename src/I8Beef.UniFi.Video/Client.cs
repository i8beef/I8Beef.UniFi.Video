using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using I8Beef.UniFi.Video.Protocol;
using I8Beef.UniFi.Video.Protocol.Bootstrap;
using I8Beef.UniFi.Video.Protocol.Camera;
using I8Beef.UniFi.Video.Protocol.Motion;
using I8Beef.UniFi.Video.Protocol.Recording;
using I8Beef.UniFi.Video.Protocol.Stream;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace I8Beef.UniFi.Video
{
    /// <inheritdoc />
    public class Client : IClient
    {
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;

        private readonly HttpClient _httpClient;
        private readonly HttpClientHandler _httpClientHandler;
        private readonly CookieContainer _cookieContainer;

        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="host">NVR IP.</param>
        /// <param name="username">NVR username.</param>
        /// <param name="password">NVR password.</param>
        /// <param name="disableCertCheck">Optional flag to turn off cert validation.</param>
        public Client(string host, string username, string password, bool disableCertCheck = false)
        {
            _host = host;
            _username = username;
            _password = password;

            _cookieContainer = new CookieContainer();
            _httpClientHandler = new HttpClientHandler { CookieContainer = _cookieContainer };
            if (disableCertCheck)
                _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            _httpClient = new HttpClient(_httpClientHandler);
        }

        /// <inheritdoc />
        public bool IsAuthenticated { get; private set; }

        /// <inheritdoc />
        public async Task AuthorizeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var body = new StringContent("{\"email\":\"" + _username + "\", \"password\":\"" + _password + "\"}", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_host + "/api/2.0/login", body, cancellationToken)
                .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var cookieHeader = response.Headers.GetValues("set-cookie").FirstOrDefault();
            if (cookieHeader != null)
            {
                _cookieContainer.SetCookies(new Uri(_host), cookieHeader);
            }

            IsAuthenticated = true;
        }

        /// <inheritdoc />
        public async Task<Bootstrap> BootstrapAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetAsync($"/api/2.0/bootstrap", null, cancellationToken).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Response<Bootstrap>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), _jsonSettings)
                .Data.FirstOrDefault();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Camera>> CameraAsync(string cameraId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetAsync("/api/2.0/camera" + (!string.IsNullOrEmpty(cameraId) ? $"/{cameraId}" : string.Empty), null, cancellationToken)
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Response<Camera>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), _jsonSettings)
                .Data;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CameraMotion>> MotionAlertsAsync(
            DateTime startTime,
            DateTime endTime,
            int intervalSeconds = 2,
            IEnumerable<string> cameraIds = null,
            string sortBy = "startTime",
            string sort = "asc",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // Minimum resolution for UniFi is 2 seconds
            if (intervalSeconds < 2)
                intervalSeconds = 2;
            if (intervalSeconds > 30)
                intervalSeconds = 30;

            var jsStartTime = startTime.RemoveMilliseconds().ToUnixTimestamp();
            var jsEndTime = endTime.RemoveMilliseconds().ToUnixTimestamp();

            var queryParams = new List<string>
            {
                $"startTime={jsStartTime}",
                $"endTime={jsEndTime}",
                $"interval={intervalSeconds * 1000}",
                $"sortBy={sortBy}",
                $"sort={sort}"
            };

            if (cameraIds != null)
                queryParams.AddRange(cameraIds.Select(x => $"cameras%5B%5D={x}"));

            var response = await GetAsync("/api/2.0/motion", queryParams, cancellationToken)
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Response<CameraMotion>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), _jsonSettings)
                .Data;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Recording>> RecordingAsync(
            DateTime startTime,
            DateTime endTime,
            IEnumerable<string> cameraIds = null,
            IEnumerable<RecordingEventType> causes = null,
            string sortBy = "startTime",
            string sort = "desc",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var jsStartTime = startTime.RemoveMilliseconds().ToUnixTimestamp();
            var jsEndTime = endTime.RemoveMilliseconds().ToUnixTimestamp();

            var queryParams = new List<string>
            {
                $"startTime={jsStartTime}",
                $"endTime={jsEndTime}",
                $"idsOnly=false",
                $"sortBy={sortBy}",
                $"sort={sort}"
            };

            if (causes != null)
                queryParams.AddRange(causes.Select(x => $"cause%5B%5D={x.ToString().FirstCharToLower()}"));
            if (cameraIds != null)
                queryParams.AddRange(cameraIds.Select(x => $"cameras%5B%5D={x}"));

            var response = await GetAsync("/api/2.0/recording", queryParams, cancellationToken)
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Response<Recording>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), _jsonSettings)
                .Data;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<string>> RecordingIdAsync(
            DateTime startTime,
            DateTime endTime,
            IEnumerable<string> cameraIds = null,
            IEnumerable<RecordingEventType> causes = null,
            string sortBy = "startTime",
            string sort = "asc",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var jsStartTime = startTime.RemoveMilliseconds().ToUnixTimestamp();
            var jsEndTime = endTime.RemoveMilliseconds().ToUnixTimestamp();

            var queryParams = new List<string>
            {
                $"startTime={jsStartTime}",
                $"endTime={jsEndTime}",
                $"idsOnly=true",
                $"sortBy={sortBy}",
                $"sort={sort}"
            };

            if (causes != null)
                queryParams.AddRange(causes.Select(x => $"cause%5B%5D={x.ToString().FirstCharToLower()}"));
            if (cameraIds != null)
                queryParams.AddRange(cameraIds.Select(x => $"cameras%5B%5D={x}"));

            var response = await GetAsync("/api/2.0/recording", queryParams, cancellationToken)
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Response<string>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), _jsonSettings)
                .Data;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<StreamUrls>> StreamUrlAsync(string cameraId, int channel, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetAsync($"/api/2.0/stream/{cameraId}/{channel}/url", null, cancellationToken)
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Response<StreamUrls>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false), _jsonSettings)
                .Data;
        }

        /// <summary>
        /// Gets the URL specified and returns the result.
        /// </summary>
        /// <param name="relativeUrl">Relative URL to query.</param>
        /// <param name="queryParams">Query parameters to pass.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        private async Task<HttpResponseMessage> GetAsync(
            string relativeUrl,
            IEnumerable<string> queryParams = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!IsAuthenticated)
                await AuthorizeAsync();

            var url = _host + relativeUrl + (queryParams != null && queryParams.Any() ? "?" + string.Join("&", queryParams) : string.Empty);
            var response = await _httpClient.GetAsync(url, cancellationToken)
                .ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                IsAuthenticated = false;

            response.EnsureSuccessStatusCode();

            return response;
        }

        #region IDisposable Support

        /// <summary>
        /// Disposable implementation.
        /// </summary>
        /// <param name="disposing">Indicates if called as part of Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            // Dispose managed state (managed objects).
            if (disposing)
            {
                // Dispose the http client
                if (_httpClient != null)
                    _httpClient.Dispose();

                if (_httpClientHandler != null)
                    _httpClientHandler.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Disposable implementation.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
