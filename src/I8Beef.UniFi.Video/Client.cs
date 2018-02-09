using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace I8Beef.UniFi.Video
{
    /// <summary>
    /// UniFi Video Client.
    /// </summary>
    public class Client : IDisposable
    {
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;

        private readonly HttpClient _httpClient;
        private readonly HttpClientHandler _httpClientHandler;
        private readonly CookieContainer _cookieContainer;

        private bool _disposed = false;

        private string _apiKey = string.Empty;

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

        /// <summary>
        /// Indicates if the client is currently authenticated.
        /// </summary>
        public bool IsAuthenticated { get; private set; }

        /// <summary>
        /// Authorize with NVR.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable <see cref="Task"/>.</returns>
        public async Task AuthorizeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var body = new StringContent("{\"email\":\"" + _username + "\", \"password\":\"" + _password + "\"}", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_host + "/api/2.0/login", body, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var cookieHeader = response.Headers.GetValues("set-cookie").FirstOrDefault();
            if (cookieHeader != null)
            {
                _cookieContainer.SetCookies(new Uri(_host), cookieHeader);
            }

            dynamic responseContent = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            _apiKey = responseContent.data[0].apiKey;

            IsAuthenticated = true;
        }

        /// <summary>
        /// Gets NVR Bootstrap information, which contains most of current state.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        public async Task<dynamic> BootstrapAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetAsync($"/api/2.0/bootstrap", cancellationToken).ConfigureAwait(false);

            return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Gets NVR camera information for all cameras.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dictionary of dynamic objects containing the JSON response.</returns>
        public async Task<IDictionary<string, dynamic>> CamerasAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var bootstrap = await BootstrapAsync(cancellationToken).ConfigureAwait(false);
            var result = new Dictionary<string, dynamic>();
            foreach (var camera in bootstrap.data[0].cameras)
            {
                string cameraId = camera.platform != null ? camera._id : camera.uuid;
                result[cameraId] = camera;
            }

            return result;
        }

        /// <summary>
        /// Gets NVR camera information for a single camera.
        /// </summary>
        /// <param name="cameraId">Camera ID to query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        public async Task<dynamic> CameraAsync(string cameraId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetAsync($"/api/2.0/camera/{cameraId}?apiKey={_apiKey}", cancellationToken).ConfigureAwait(false);

            return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Gets the URL specified and returns the result.
        /// </summary>
        /// <param name="relativeUrl">Relative URL to query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A dynamic object containing the JSON response.</returns>
        private async Task<HttpResponseMessage> GetAsync(string relativeUrl, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!IsAuthenticated)
                await AuthorizeAsync();

            var response = await _httpClient.GetAsync(_host + relativeUrl, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                IsAuthenticated = false;
                _apiKey = string.Empty;
            }

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

            if (disposing)
            {
                // Dispose managed state (managed objects).
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
