using System.Collections.Generic;
using I8Beef.UniFi.Video.Protocol.Common;

namespace I8Beef.UniFi.Video.Protocol.Bootstrap
{
    /// <summary>
    /// Bootstrap response.
    /// </summary>
    public class Bootstrap
    {
        /// <summary>
        /// Admin user group id.
        /// </summary>
        public string AdminUserGroupId { get; set; }

        /// <summary>
        /// Alert schedules.
        /// </summary>
        public IList<dynamic> AlertSchedules { get; set; }

        /// <summary>
        /// Camera schedules.
        /// </summary>
        public IList<dynamic> CameraSchedules { get; set; }

        /// <summary>
        /// Cameras.
        /// </summary>
        public IList<Camera.Camera> Cameras { get; set; }

        /// <summary>
        /// Cloud host.  Usually video.ubnt.com.
        /// </summary>
        public string CloudHost { get; set; }

        /// <summary>
        /// Firmwares.
        /// </summary>
        public IList<Firmware> Firmware { get; set; }

        /// <summary>
        /// Is the system factory defaulted?
        /// </summary>
        public bool IsFactoryDefault { get; set; }

        /// <summary>
        /// Is this an offical Ubiquiti NVR?
        /// </summary>
        public bool IsHardwareNvr { get; set; }

        /// <summary>
        /// Is the current user logged in?
        /// </summary>
        public bool IsLoggedIn { get; set; }

        /// <summary>
        /// Live views.
        /// </summary>
        public IList<LiveView> LiveViews { get; set; }

        /// <summary>
        /// Maps.
        /// </summary>
        public IList<Map> Maps { get; set; }

        /// <summary>
        /// New critical alerts.
        /// </summary>
        public int NewCriticalAlerts { get; set; }

        /// <summary>
        /// Nvr name.
        /// </summary>
        public string NvrName { get; set; }

        /// <summary>
        /// Servers.
        /// </summary>
        public IList<Server> Servers { get; set; }

        /// <summary>
        /// Service state.
        /// </summary>
        public string ServiceState { get; set; }
    }
}
