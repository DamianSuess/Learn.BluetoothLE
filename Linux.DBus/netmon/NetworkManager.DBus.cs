using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus;

[assembly: InternalsVisibleTo(Tmds.DBus.Connection.DynamicAssemblyName)]
namespace NetworkManager.DBus
{
    [DBusInterface("org.freedesktop.DBus.ObjectManager")]
    interface IObjectManager : IDBusObject
    {
        Task<IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>>> GetManagedObjectsAsync();
        Task<IDisposable> WatchInterfacesAddedAsync(Action<(ObjectPath objectPath, IDictionary<string, IDictionary<string, object>> interfacesAndProperties)> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchInterfacesRemovedAsync(Action<(ObjectPath objectPath, string[] interfaces)> handler, Action<Exception> onError = null);
    }

    [DBusInterface("org.freedesktop.NetworkManager")]
    interface INetworkManager : IDBusObject
    {
        Task ReloadAsync(uint Flags);
        
        //// Task<ObjectPath[]> GetDevicesAsync();
        Task<IDevice[]> GetDevicesAsync();

        Task<ObjectPath[]> GetAllDevicesAsync();
        Task<ObjectPath> GetDeviceByIpIfaceAsync(string Iface);
        Task<ObjectPath> ActivateConnectionAsync(ObjectPath Connection, ObjectPath Device, ObjectPath SpecificObject);
        Task<(ObjectPath path, ObjectPath activeConnection)> AddAndActivateConnectionAsync(IDictionary<string, IDictionary<string, object>> Connection, ObjectPath Device, ObjectPath SpecificObject);
        Task<(ObjectPath path, ObjectPath activeConnection, IDictionary<string, object> result)> AddAndActivateConnection2Async(IDictionary<string, IDictionary<string, object>> Connection, ObjectPath Device, ObjectPath SpecificObject, IDictionary<string, object> Options);
        Task DeactivateConnectionAsync(ObjectPath ActiveConnection);
        Task SleepAsync(bool Sleep);
        Task EnableAsync(bool Enable);
        Task<IDictionary<string, string>> GetPermissionsAsync();
        Task SetLoggingAsync(string Level, string Domains);
        Task<(string level, string domains)> GetLoggingAsync();
        Task<uint> CheckConnectivityAsync();
        Task<uint> stateAsync();
        Task<ObjectPath> CheckpointCreateAsync(ObjectPath[] Devices, uint RollbackTimeout, uint Flags);
        Task CheckpointDestroyAsync(ObjectPath Checkpoint);
        Task<IDictionary<string, uint>> CheckpointRollbackAsync(ObjectPath Checkpoint);
        Task CheckpointAdjustRollbackTimeoutAsync(ObjectPath Checkpoint, uint AddTimeout);
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchCheckPermissionsAsync(Action handler, Action<Exception> onError = null);
        Task<IDisposable> WatchStateChangedAsync(Action<uint> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDeviceAddedAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchDeviceRemovedAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<NetworkManagerProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class NetworkManagerProperties
    {
        private ObjectPath[] _Devices = default(ObjectPath[]);
        public ObjectPath[] Devices
        {
            get
            {
                return _Devices;
            }

            set
            {
                _Devices = (value);
            }
        }

        private ObjectPath[] _AllDevices = default(ObjectPath[]);
        public ObjectPath[] AllDevices
        {
            get
            {
                return _AllDevices;
            }

            set
            {
                _AllDevices = (value);
            }
        }

        private ObjectPath[] _Checkpoints = default(ObjectPath[]);
        public ObjectPath[] Checkpoints
        {
            get
            {
                return _Checkpoints;
            }

            set
            {
                _Checkpoints = (value);
            }
        }

        private bool _NetworkingEnabled = default(bool);
        public bool NetworkingEnabled
        {
            get
            {
                return _NetworkingEnabled;
            }

            set
            {
                _NetworkingEnabled = (value);
            }
        }

        private bool _WirelessEnabled = default(bool);
        public bool WirelessEnabled
        {
            get
            {
                return _WirelessEnabled;
            }

            set
            {
                _WirelessEnabled = (value);
            }
        }

        private bool _WirelessHardwareEnabled = default(bool);
        public bool WirelessHardwareEnabled
        {
            get
            {
                return _WirelessHardwareEnabled;
            }

            set
            {
                _WirelessHardwareEnabled = (value);
            }
        }

        private bool _WwanEnabled = default(bool);
        public bool WwanEnabled
        {
            get
            {
                return _WwanEnabled;
            }

            set
            {
                _WwanEnabled = (value);
            }
        }

        private bool _WwanHardwareEnabled = default(bool);
        public bool WwanHardwareEnabled
        {
            get
            {
                return _WwanHardwareEnabled;
            }

            set
            {
                _WwanHardwareEnabled = (value);
            }
        }

        private bool _WimaxEnabled = default(bool);
        public bool WimaxEnabled
        {
            get
            {
                return _WimaxEnabled;
            }

            set
            {
                _WimaxEnabled = (value);
            }
        }

        private bool _WimaxHardwareEnabled = default(bool);
        public bool WimaxHardwareEnabled
        {
            get
            {
                return _WimaxHardwareEnabled;
            }

            set
            {
                _WimaxHardwareEnabled = (value);
            }
        }

        private ObjectPath[] _ActiveConnections = default(ObjectPath[]);
        public ObjectPath[] ActiveConnections
        {
            get
            {
                return _ActiveConnections;
            }

            set
            {
                _ActiveConnections = (value);
            }
        }

        private ObjectPath _PrimaryConnection = default(ObjectPath);
        public ObjectPath PrimaryConnection
        {
            get
            {
                return _PrimaryConnection;
            }

            set
            {
                _PrimaryConnection = (value);
            }
        }

        private string _PrimaryConnectionType = default(string);
        public string PrimaryConnectionType
        {
            get
            {
                return _PrimaryConnectionType;
            }

            set
            {
                _PrimaryConnectionType = (value);
            }
        }

        private uint _Metered = default(uint);
        public uint Metered
        {
            get
            {
                return _Metered;
            }

            set
            {
                _Metered = (value);
            }
        }

        private ObjectPath _ActivatingConnection = default(ObjectPath);
        public ObjectPath ActivatingConnection
        {
            get
            {
                return _ActivatingConnection;
            }

            set
            {
                _ActivatingConnection = (value);
            }
        }

        private bool _Startup = default(bool);
        public bool Startup
        {
            get
            {
                return _Startup;
            }

            set
            {
                _Startup = (value);
            }
        }

        private string _Version = default(string);
        public string Version
        {
            get
            {
                return _Version;
            }

            set
            {
                _Version = (value);
            }
        }

        private uint[] _Capabilities = default(uint[]);
        public uint[] Capabilities
        {
            get
            {
                return _Capabilities;
            }

            set
            {
                _Capabilities = (value);
            }
        }

        private uint _State = default(uint);
        public uint State
        {
            get
            {
                return _State;
            }

            set
            {
                _State = (value);
            }
        }

        private uint _Connectivity = default(uint);
        public uint Connectivity
        {
            get
            {
                return _Connectivity;
            }

            set
            {
                _Connectivity = (value);
            }
        }

        private bool _ConnectivityCheckAvailable = default(bool);
        public bool ConnectivityCheckAvailable
        {
            get
            {
                return _ConnectivityCheckAvailable;
            }

            set
            {
                _ConnectivityCheckAvailable = (value);
            }
        }

        private bool _ConnectivityCheckEnabled = default(bool);
        public bool ConnectivityCheckEnabled
        {
            get
            {
                return _ConnectivityCheckEnabled;
            }

            set
            {
                _ConnectivityCheckEnabled = (value);
            }
        }

        private string _ConnectivityCheckUri = default(string);
        public string ConnectivityCheckUri
        {
            get
            {
                return _ConnectivityCheckUri;
            }

            set
            {
                _ConnectivityCheckUri = (value);
            }
        }

        private IDictionary<string, object> _GlobalDnsConfiguration = default(IDictionary<string, object>);
        public IDictionary<string, object> GlobalDnsConfiguration
        {
            get
            {
                return _GlobalDnsConfiguration;
            }

            set
            {
                _GlobalDnsConfiguration = (value);
            }
        }
    }

    static class NetworkManagerExtensions
    {
        public static Task<ObjectPath[]> GetDevicesAsync(this INetworkManager o) => o.GetAsync<ObjectPath[]>("Devices");
        public static Task<ObjectPath[]> GetAllDevicesAsync(this INetworkManager o) => o.GetAsync<ObjectPath[]>("AllDevices");
        public static Task<ObjectPath[]> GetCheckpointsAsync(this INetworkManager o) => o.GetAsync<ObjectPath[]>("Checkpoints");
        public static Task<bool> GetNetworkingEnabledAsync(this INetworkManager o) => o.GetAsync<bool>("NetworkingEnabled");
        public static Task<bool> GetWirelessEnabledAsync(this INetworkManager o) => o.GetAsync<bool>("WirelessEnabled");
        public static Task<bool> GetWirelessHardwareEnabledAsync(this INetworkManager o) => o.GetAsync<bool>("WirelessHardwareEnabled");
        public static Task<bool> GetWwanEnabledAsync(this INetworkManager o) => o.GetAsync<bool>("WwanEnabled");
        public static Task<bool> GetWwanHardwareEnabledAsync(this INetworkManager o) => o.GetAsync<bool>("WwanHardwareEnabled");
        public static Task<bool> GetWimaxEnabledAsync(this INetworkManager o) => o.GetAsync<bool>("WimaxEnabled");
        public static Task<bool> GetWimaxHardwareEnabledAsync(this INetworkManager o) => o.GetAsync<bool>("WimaxHardwareEnabled");
        public static Task<ObjectPath[]> GetActiveConnectionsAsync(this INetworkManager o) => o.GetAsync<ObjectPath[]>("ActiveConnections");
        public static Task<ObjectPath> GetPrimaryConnectionAsync(this INetworkManager o) => o.GetAsync<ObjectPath>("PrimaryConnection");
        public static Task<string> GetPrimaryConnectionTypeAsync(this INetworkManager o) => o.GetAsync<string>("PrimaryConnectionType");
        public static Task<uint> GetMeteredAsync(this INetworkManager o) => o.GetAsync<uint>("Metered");
        public static Task<ObjectPath> GetActivatingConnectionAsync(this INetworkManager o) => o.GetAsync<ObjectPath>("ActivatingConnection");
        public static Task<bool> GetStartupAsync(this INetworkManager o) => o.GetAsync<bool>("Startup");
        public static Task<string> GetVersionAsync(this INetworkManager o) => o.GetAsync<string>("Version");
        public static Task<uint[]> GetCapabilitiesAsync(this INetworkManager o) => o.GetAsync<uint[]>("Capabilities");
        public static Task<uint> GetStateAsync(this INetworkManager o) => o.GetAsync<uint>("State");
        public static Task<uint> GetConnectivityAsync(this INetworkManager o) => o.GetAsync<uint>("Connectivity");
        public static Task<bool> GetConnectivityCheckAvailableAsync(this INetworkManager o) => o.GetAsync<bool>("ConnectivityCheckAvailable");
        public static Task<bool> GetConnectivityCheckEnabledAsync(this INetworkManager o) => o.GetAsync<bool>("ConnectivityCheckEnabled");
        public static Task<string> GetConnectivityCheckUriAsync(this INetworkManager o) => o.GetAsync<string>("ConnectivityCheckUri");
        public static Task<IDictionary<string, object>> GetGlobalDnsConfigurationAsync(this INetworkManager o) => o.GetAsync<IDictionary<string, object>>("GlobalDnsConfiguration");
        public static Task SetWirelessEnabledAsync(this INetworkManager o, bool val) => o.SetAsync("WirelessEnabled", val);
        public static Task SetWwanEnabledAsync(this INetworkManager o, bool val) => o.SetAsync("WwanEnabled", val);
        public static Task SetWimaxEnabledAsync(this INetworkManager o, bool val) => o.SetAsync("WimaxEnabled", val);
        public static Task SetConnectivityCheckEnabledAsync(this INetworkManager o, bool val) => o.SetAsync("ConnectivityCheckEnabled", val);
        public static Task SetGlobalDnsConfigurationAsync(this INetworkManager o, IDictionary<string, object> val) => o.SetAsync("GlobalDnsConfiguration", val);
    }

    [DBusInterface("org.freedesktop.NetworkManager.AgentManager")]
    interface IAgentManager : IDBusObject
    {
        Task RegisterAsync(string Identifier);
        Task RegisterWithCapabilitiesAsync(string Identifier, uint Capabilities);
        Task UnregisterAsync();
    }

    [DBusInterface("org.freedesktop.NetworkManager.Settings")]
    interface ISettings : IDBusObject
    {
        Task<ObjectPath[]> ListConnectionsAsync();
        Task<ObjectPath> GetConnectionByUuidAsync(string Uuid);
        Task<ObjectPath> AddConnectionAsync(IDictionary<string, IDictionary<string, object>> Connection);
        Task<ObjectPath> AddConnectionUnsavedAsync(IDictionary<string, IDictionary<string, object>> Connection);
        Task<(ObjectPath path, IDictionary<string, object> result)> AddConnection2Async(IDictionary<string, IDictionary<string, object>> Settings, uint Flags, IDictionary<string, object> Args);
        Task<(bool status, string[] failures)> LoadConnectionsAsync(string[] Filenames);
        Task<bool> ReloadConnectionsAsync();
        Task SaveHostnameAsync(string Hostname);
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchNewConnectionAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchConnectionRemovedAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<SettingsProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class SettingsProperties
    {
        private ObjectPath[] _Connections = default(ObjectPath[]);
        public ObjectPath[] Connections
        {
            get
            {
                return _Connections;
            }

            set
            {
                _Connections = (value);
            }
        }

        private string _Hostname = default(string);
        public string Hostname
        {
            get
            {
                return _Hostname;
            }

            set
            {
                _Hostname = (value);
            }
        }

        private bool _CanModify = default(bool);
        public bool CanModify
        {
            get
            {
                return _CanModify;
            }

            set
            {
                _CanModify = (value);
            }
        }
    }

    static class SettingsExtensions
    {
        public static Task<ObjectPath[]> GetConnectionsAsync(this ISettings o) => o.GetAsync<ObjectPath[]>("Connections");
        public static Task<string> GetHostnameAsync(this ISettings o) => o.GetAsync<string>("Hostname");
        public static Task<bool> GetCanModifyAsync(this ISettings o) => o.GetAsync<bool>("CanModify");
    }

    [DBusInterface("org.freedesktop.NetworkManager.Settings.Connection")]
    interface IConnection : IDBusObject
    {
        Task UpdateAsync(IDictionary<string, IDictionary<string, object>> Properties);
        Task UpdateUnsavedAsync(IDictionary<string, IDictionary<string, object>> Properties);
        Task DeleteAsync();
        Task<IDictionary<string, IDictionary<string, object>>> GetSettingsAsync();
        Task<IDictionary<string, IDictionary<string, object>>> GetSecretsAsync(string SettingName);
        Task ClearSecretsAsync();
        Task SaveAsync();
        Task<IDictionary<string, object>> Update2Async(IDictionary<string, IDictionary<string, object>> Settings, uint Flags, IDictionary<string, object> Args);
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchUpdatedAsync(Action handler, Action<Exception> onError = null);
        Task<IDisposable> WatchRemovedAsync(Action handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<ConnectionProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class ConnectionProperties
    {
        private bool _Unsaved = default(bool);
        public bool Unsaved
        {
            get
            {
                return _Unsaved;
            }

            set
            {
                _Unsaved = (value);
            }
        }

        private uint _Flags = default(uint);
        public uint Flags
        {
            get
            {
                return _Flags;
            }

            set
            {
                _Flags = (value);
            }
        }

        private string _Filename = default(string);
        public string Filename
        {
            get
            {
                return _Filename;
            }

            set
            {
                _Filename = (value);
            }
        }
    }

    static class ConnectionExtensions
    {
        public static Task<bool> GetUnsavedAsync(this IConnection o) => o.GetAsync<bool>("Unsaved");
        public static Task<uint> GetFlagsAsync(this IConnection o) => o.GetAsync<uint>("Flags");
        public static Task<string> GetFilenameAsync(this IConnection o) => o.GetAsync<string>("Filename");
    }

    [DBusInterface("org.freedesktop.NetworkManager.Device.Statistics")]
    interface IStatistics : IDBusObject
    {
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<StatisticsProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class StatisticsProperties
    {
        private uint _RefreshRateMs = default(uint);
        public uint RefreshRateMs
        {
            get
            {
                return _RefreshRateMs;
            }

            set
            {
                _RefreshRateMs = (value);
            }
        }

        private ulong _TxBytes = default(ulong);
        public ulong TxBytes
        {
            get
            {
                return _TxBytes;
            }

            set
            {
                _TxBytes = (value);
            }
        }

        private ulong _RxBytes = default(ulong);
        public ulong RxBytes
        {
            get
            {
                return _RxBytes;
            }

            set
            {
                _RxBytes = (value);
            }
        }
    }

    static class StatisticsExtensions
    {
        public static Task<uint> GetRefreshRateMsAsync(this IStatistics o) => o.GetAsync<uint>("RefreshRateMs");
        public static Task<ulong> GetTxBytesAsync(this IStatistics o) => o.GetAsync<ulong>("TxBytes");
        public static Task<ulong> GetRxBytesAsync(this IStatistics o) => o.GetAsync<ulong>("RxBytes");
        public static Task SetRefreshRateMsAsync(this IStatistics o, uint val) => o.SetAsync("RefreshRateMs", val);
    }

    [DBusInterface("org.freedesktop.NetworkManager.Device")]
    interface IDevice : IDBusObject
    {
        Task ReapplyAsync(IDictionary<string, IDictionary<string, object>> Connection, ulong VersionId, uint Flags);
        Task<(IDictionary<string, IDictionary<string, object>> connection, ulong versionId)> GetAppliedConnectionAsync(uint Flags);
        Task DisconnectAsync();
        Task DeleteAsync();
        Task<IDisposable> WatchStateChangedAsync(Action<(uint newState, uint oldState, uint reason)> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<DeviceProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class DeviceProperties
    {
        private string _Udi = default(string);
        public string Udi
        {
            get
            {
                return _Udi;
            }

            set
            {
                _Udi = (value);
            }
        }

        private string _Path = default(string);
        public string Path
        {
            get
            {
                return _Path;
            }

            set
            {
                _Path = (value);
            }
        }

        private string _Interface = default(string);
        public string Interface
        {
            get
            {
                return _Interface;
            }

            set
            {
                _Interface = (value);
            }
        }

        private string _IpInterface = default(string);
        public string IpInterface
        {
            get
            {
                return _IpInterface;
            }

            set
            {
                _IpInterface = (value);
            }
        }

        private string _Driver = default(string);
        public string Driver
        {
            get
            {
                return _Driver;
            }

            set
            {
                _Driver = (value);
            }
        }

        private string _DriverVersion = default(string);
        public string DriverVersion
        {
            get
            {
                return _DriverVersion;
            }

            set
            {
                _DriverVersion = (value);
            }
        }

        private string _FirmwareVersion = default(string);
        public string FirmwareVersion
        {
            get
            {
                return _FirmwareVersion;
            }

            set
            {
                _FirmwareVersion = (value);
            }
        }

        private uint _Capabilities = default(uint);
        public uint Capabilities
        {
            get
            {
                return _Capabilities;
            }

            set
            {
                _Capabilities = (value);
            }
        }

        private uint _Ip4Address = default(uint);
        public uint Ip4Address
        {
            get
            {
                return _Ip4Address;
            }

            set
            {
                _Ip4Address = (value);
            }
        }

        private uint _State = default(uint);
        public uint State
        {
            get
            {
                return _State;
            }

            set
            {
                _State = (value);
            }
        }

        private (uint, uint) _StateReason = default((uint, uint));
        public (uint, uint) StateReason
        {
            get
            {
                return _StateReason;
            }

            set
            {
                _StateReason = (value);
            }
        }

        private ObjectPath _ActiveConnection = default(ObjectPath);
        public ObjectPath ActiveConnection
        {
            get
            {
                return _ActiveConnection;
            }

            set
            {
                _ActiveConnection = (value);
            }
        }

        private ObjectPath _Ip4Config = default(ObjectPath);
        public ObjectPath Ip4Config
        {
            get
            {
                return _Ip4Config;
            }

            set
            {
                _Ip4Config = (value);
            }
        }

        private ObjectPath _Dhcp4Config = default(ObjectPath);
        public ObjectPath Dhcp4Config
        {
            get
            {
                return _Dhcp4Config;
            }

            set
            {
                _Dhcp4Config = (value);
            }
        }

        private ObjectPath _Ip6Config = default(ObjectPath);
        public ObjectPath Ip6Config
        {
            get
            {
                return _Ip6Config;
            }

            set
            {
                _Ip6Config = (value);
            }
        }

        private ObjectPath _Dhcp6Config = default(ObjectPath);
        public ObjectPath Dhcp6Config
        {
            get
            {
                return _Dhcp6Config;
            }

            set
            {
                _Dhcp6Config = (value);
            }
        }

        private bool _Managed = default(bool);
        public bool Managed
        {
            get
            {
                return _Managed;
            }

            set
            {
                _Managed = (value);
            }
        }

        private bool _Autoconnect = default(bool);
        public bool Autoconnect
        {
            get
            {
                return _Autoconnect;
            }

            set
            {
                _Autoconnect = (value);
            }
        }

        private bool _FirmwareMissing = default(bool);
        public bool FirmwareMissing
        {
            get
            {
                return _FirmwareMissing;
            }

            set
            {
                _FirmwareMissing = (value);
            }
        }

        private bool _NmPluginMissing = default(bool);
        public bool NmPluginMissing
        {
            get
            {
                return _NmPluginMissing;
            }

            set
            {
                _NmPluginMissing = (value);
            }
        }

        private uint _DeviceType = default(uint);
        public uint DeviceType
        {
            get
            {
                return _DeviceType;
            }

            set
            {
                _DeviceType = (value);
            }
        }

        private ObjectPath[] _AvailableConnections = default(ObjectPath[]);
        public ObjectPath[] AvailableConnections
        {
            get
            {
                return _AvailableConnections;
            }

            set
            {
                _AvailableConnections = (value);
            }
        }

        private string _PhysicalPortId = default(string);
        public string PhysicalPortId
        {
            get
            {
                return _PhysicalPortId;
            }

            set
            {
                _PhysicalPortId = (value);
            }
        }

        private uint _Mtu = default(uint);
        public uint Mtu
        {
            get
            {
                return _Mtu;
            }

            set
            {
                _Mtu = (value);
            }
        }

        private uint _Metered = default(uint);
        public uint Metered
        {
            get
            {
                return _Metered;
            }

            set
            {
                _Metered = (value);
            }
        }

        private IDictionary<string, object>[] _LldpNeighbors = default(IDictionary<string, object>[]);
        public IDictionary<string, object>[] LldpNeighbors
        {
            get
            {
                return _LldpNeighbors;
            }

            set
            {
                _LldpNeighbors = (value);
            }
        }

        private bool _Real = default(bool);
        public bool Real
        {
            get
            {
                return _Real;
            }

            set
            {
                _Real = (value);
            }
        }

        private uint _Ip4Connectivity = default(uint);
        public uint Ip4Connectivity
        {
            get
            {
                return _Ip4Connectivity;
            }

            set
            {
                _Ip4Connectivity = (value);
            }
        }

        private uint _Ip6Connectivity = default(uint);
        public uint Ip6Connectivity
        {
            get
            {
                return _Ip6Connectivity;
            }

            set
            {
                _Ip6Connectivity = (value);
            }
        }

        private uint _InterfaceFlags = default(uint);
        public uint InterfaceFlags
        {
            get
            {
                return _InterfaceFlags;
            }

            set
            {
                _InterfaceFlags = (value);
            }
        }

        private string _HwAddress = default(string);
        public string HwAddress
        {
            get
            {
                return _HwAddress;
            }

            set
            {
                _HwAddress = (value);
            }
        }
    }

    static class DeviceExtensions
    {
        public static Task<string> GetUdiAsync(this IDevice o) => o.GetAsync<string>("Udi");
        public static Task<string> GetPathAsync(this IDevice o) => o.GetAsync<string>("Path");
        public static Task<string> GetInterfaceAsync(this IDevice o) => o.GetAsync<string>("Interface");
        public static Task<string> GetIpInterfaceAsync(this IDevice o) => o.GetAsync<string>("IpInterface");
        public static Task<string> GetDriverAsync(this IDevice o) => o.GetAsync<string>("Driver");
        public static Task<string> GetDriverVersionAsync(this IDevice o) => o.GetAsync<string>("DriverVersion");
        public static Task<string> GetFirmwareVersionAsync(this IDevice o) => o.GetAsync<string>("FirmwareVersion");
        public static Task<uint> GetCapabilitiesAsync(this IDevice o) => o.GetAsync<uint>("Capabilities");
        public static Task<uint> GetIp4AddressAsync(this IDevice o) => o.GetAsync<uint>("Ip4Address");
        public static Task<uint> GetStateAsync(this IDevice o) => o.GetAsync<uint>("State");
        public static Task<(uint, uint)> GetStateReasonAsync(this IDevice o) => o.GetAsync<(uint, uint)>("StateReason");
        public static Task<ObjectPath> GetActiveConnectionAsync(this IDevice o) => o.GetAsync<ObjectPath>("ActiveConnection");
        public static Task<ObjectPath> GetIp4ConfigAsync(this IDevice o) => o.GetAsync<ObjectPath>("Ip4Config");
        public static Task<ObjectPath> GetDhcp4ConfigAsync(this IDevice o) => o.GetAsync<ObjectPath>("Dhcp4Config");
        public static Task<ObjectPath> GetIp6ConfigAsync(this IDevice o) => o.GetAsync<ObjectPath>("Ip6Config");
        public static Task<ObjectPath> GetDhcp6ConfigAsync(this IDevice o) => o.GetAsync<ObjectPath>("Dhcp6Config");
        public static Task<bool> GetManagedAsync(this IDevice o) => o.GetAsync<bool>("Managed");
        public static Task<bool> GetAutoconnectAsync(this IDevice o) => o.GetAsync<bool>("Autoconnect");
        public static Task<bool> GetFirmwareMissingAsync(this IDevice o) => o.GetAsync<bool>("FirmwareMissing");
        public static Task<bool> GetNmPluginMissingAsync(this IDevice o) => o.GetAsync<bool>("NmPluginMissing");
        public static Task<uint> GetDeviceTypeAsync(this IDevice o) => o.GetAsync<uint>("DeviceType");
        public static Task<ObjectPath[]> GetAvailableConnectionsAsync(this IDevice o) => o.GetAsync<ObjectPath[]>("AvailableConnections");
        public static Task<string> GetPhysicalPortIdAsync(this IDevice o) => o.GetAsync<string>("PhysicalPortId");
        public static Task<uint> GetMtuAsync(this IDevice o) => o.GetAsync<uint>("Mtu");
        public static Task<uint> GetMeteredAsync(this IDevice o) => o.GetAsync<uint>("Metered");
        public static Task<IDictionary<string, object>[]> GetLldpNeighborsAsync(this IDevice o) => o.GetAsync<IDictionary<string, object>[]>("LldpNeighbors");
        public static Task<bool> GetRealAsync(this IDevice o) => o.GetAsync<bool>("Real");
        public static Task<uint> GetIp4ConnectivityAsync(this IDevice o) => o.GetAsync<uint>("Ip4Connectivity");
        public static Task<uint> GetIp6ConnectivityAsync(this IDevice o) => o.GetAsync<uint>("Ip6Connectivity");
        public static Task<uint> GetInterfaceFlagsAsync(this IDevice o) => o.GetAsync<uint>("InterfaceFlags");
        public static Task<string> GetHwAddressAsync(this IDevice o) => o.GetAsync<string>("HwAddress");
        public static Task SetManagedAsync(this IDevice o, bool val) => o.SetAsync("Managed", val);
        public static Task SetAutoconnectAsync(this IDevice o, bool val) => o.SetAsync("Autoconnect", val);
    }

    [DBusInterface("org.freedesktop.NetworkManager.Device.Wired")]
    interface IWired : IDBusObject
    {
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<WiredProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class WiredProperties
    {
        private string _HwAddress = default(string);
        public string HwAddress
        {
            get
            {
                return _HwAddress;
            }

            set
            {
                _HwAddress = (value);
            }
        }

        private string _PermHwAddress = default(string);
        public string PermHwAddress
        {
            get
            {
                return _PermHwAddress;
            }

            set
            {
                _PermHwAddress = (value);
            }
        }

        private uint _Speed = default(uint);
        public uint Speed
        {
            get
            {
                return _Speed;
            }

            set
            {
                _Speed = (value);
            }
        }

        private string[] _S390Subchannels = default(string[]);
        public string[] S390Subchannels
        {
            get
            {
                return _S390Subchannels;
            }

            set
            {
                _S390Subchannels = (value);
            }
        }

        private bool _Carrier = default(bool);
        public bool Carrier
        {
            get
            {
                return _Carrier;
            }

            set
            {
                _Carrier = (value);
            }
        }
    }

    static class WiredExtensions
    {
        public static Task<string> GetHwAddressAsync(this IWired o) => o.GetAsync<string>("HwAddress");
        public static Task<string> GetPermHwAddressAsync(this IWired o) => o.GetAsync<string>("PermHwAddress");
        public static Task<uint> GetSpeedAsync(this IWired o) => o.GetAsync<uint>("Speed");
        public static Task<string[]> GetS390SubchannelsAsync(this IWired o) => o.GetAsync<string[]>("S390Subchannels");
        public static Task<bool> GetCarrierAsync(this IWired o) => o.GetAsync<bool>("Carrier");
    }

    [DBusInterface("org.freedesktop.NetworkManager.Device.Wireless")]
    interface IWireless : IDBusObject
    {
        Task<ObjectPath[]> GetAccessPointsAsync();
        Task<ObjectPath[]> GetAllAccessPointsAsync();
        Task RequestScanAsync(IDictionary<string, object> Options);
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchAccessPointAddedAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<IDisposable> WatchAccessPointRemovedAsync(Action<ObjectPath> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<WirelessProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class WirelessProperties
    {
        private string _HwAddress = default(string);
        public string HwAddress
        {
            get
            {
                return _HwAddress;
            }

            set
            {
                _HwAddress = (value);
            }
        }

        private string _PermHwAddress = default(string);
        public string PermHwAddress
        {
            get
            {
                return _PermHwAddress;
            }

            set
            {
                _PermHwAddress = (value);
            }
        }

        private uint _Mode = default(uint);
        public uint Mode
        {
            get
            {
                return _Mode;
            }

            set
            {
                _Mode = (value);
            }
        }

        private uint _Bitrate = default(uint);
        public uint Bitrate
        {
            get
            {
                return _Bitrate;
            }

            set
            {
                _Bitrate = (value);
            }
        }

        private ObjectPath[] _AccessPoints = default(ObjectPath[]);
        public ObjectPath[] AccessPoints
        {
            get
            {
                return _AccessPoints;
            }

            set
            {
                _AccessPoints = (value);
            }
        }

        private ObjectPath _ActiveAccessPoint = default(ObjectPath);
        public ObjectPath ActiveAccessPoint
        {
            get
            {
                return _ActiveAccessPoint;
            }

            set
            {
                _ActiveAccessPoint = (value);
            }
        }

        private uint _WirelessCapabilities = default(uint);
        public uint WirelessCapabilities
        {
            get
            {
                return _WirelessCapabilities;
            }

            set
            {
                _WirelessCapabilities = (value);
            }
        }

        private long _LastScan = default(long);
        public long LastScan
        {
            get
            {
                return _LastScan;
            }

            set
            {
                _LastScan = (value);
            }
        }
    }

    static class WirelessExtensions
    {
        public static Task<string> GetHwAddressAsync(this IWireless o) => o.GetAsync<string>("HwAddress");
        public static Task<string> GetPermHwAddressAsync(this IWireless o) => o.GetAsync<string>("PermHwAddress");
        public static Task<uint> GetModeAsync(this IWireless o) => o.GetAsync<uint>("Mode");
        public static Task<uint> GetBitrateAsync(this IWireless o) => o.GetAsync<uint>("Bitrate");
        public static Task<ObjectPath[]> GetAccessPointsAsync(this IWireless o) => o.GetAsync<ObjectPath[]>("AccessPoints");
        public static Task<ObjectPath> GetActiveAccessPointAsync(this IWireless o) => o.GetAsync<ObjectPath>("ActiveAccessPoint");
        public static Task<uint> GetWirelessCapabilitiesAsync(this IWireless o) => o.GetAsync<uint>("WirelessCapabilities");
        public static Task<long> GetLastScanAsync(this IWireless o) => o.GetAsync<long>("LastScan");
    }

    [DBusInterface("org.freedesktop.NetworkManager.Device.Generic")]
    interface IGeneric : IDBusObject
    {
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<GenericProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class GenericProperties
    {
        private string _HwAddress = default(string);
        public string HwAddress
        {
            get
            {
                return _HwAddress;
            }

            set
            {
                _HwAddress = (value);
            }
        }

        private string _TypeDescription = default(string);
        public string TypeDescription
        {
            get
            {
                return _TypeDescription;
            }

            set
            {
                _TypeDescription = (value);
            }
        }
    }

    static class GenericExtensions
    {
        public static Task<string> GetHwAddressAsync(this IGeneric o) => o.GetAsync<string>("HwAddress");
        public static Task<string> GetTypeDescriptionAsync(this IGeneric o) => o.GetAsync<string>("TypeDescription");
    }

    [DBusInterface("org.freedesktop.NetworkManager.IP6Config")]
    interface IIP6Config : IDBusObject
    {
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<IP6ConfigProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class IP6ConfigProperties
    {
        private (byte[], uint, byte[])[] _Addresses = default((byte[], uint, byte[])[]);
        public (byte[], uint, byte[])[] Addresses
        {
            get
            {
                return _Addresses;
            }

            set
            {
                _Addresses = (value);
            }
        }

        private IDictionary<string, object>[] _AddressData = default(IDictionary<string, object>[]);
        public IDictionary<string, object>[] AddressData
        {
            get
            {
                return _AddressData;
            }

            set
            {
                _AddressData = (value);
            }
        }

        private string _Gateway = default(string);
        public string Gateway
        {
            get
            {
                return _Gateway;
            }

            set
            {
                _Gateway = (value);
            }
        }

        private (byte[], uint, byte[], uint)[] _Routes = default((byte[], uint, byte[], uint)[]);
        public (byte[], uint, byte[], uint)[] Routes
        {
            get
            {
                return _Routes;
            }

            set
            {
                _Routes = (value);
            }
        }

        private IDictionary<string, object>[] _RouteData = default(IDictionary<string, object>[]);
        public IDictionary<string, object>[] RouteData
        {
            get
            {
                return _RouteData;
            }

            set
            {
                _RouteData = (value);
            }
        }

        private byte[][] _Nameservers = default(byte[][]);
        public byte[][] Nameservers
        {
            get
            {
                return _Nameservers;
            }

            set
            {
                _Nameservers = (value);
            }
        }

        private string[] _Domains = default(string[]);
        public string[] Domains
        {
            get
            {
                return _Domains;
            }

            set
            {
                _Domains = (value);
            }
        }

        private string[] _Searches = default(string[]);
        public string[] Searches
        {
            get
            {
                return _Searches;
            }

            set
            {
                _Searches = (value);
            }
        }

        private string[] _DnsOptions = default(string[]);
        public string[] DnsOptions
        {
            get
            {
                return _DnsOptions;
            }

            set
            {
                _DnsOptions = (value);
            }
        }

        private int _DnsPriority = default(int);
        public int DnsPriority
        {
            get
            {
                return _DnsPriority;
            }

            set
            {
                _DnsPriority = (value);
            }
        }
    }

    static class IP6ConfigExtensions
    {
        public static Task<(byte[], uint, byte[])[]> GetAddressesAsync(this IIP6Config o) => o.GetAsync<(byte[], uint, byte[])[]>("Addresses");
        public static Task<IDictionary<string, object>[]> GetAddressDataAsync(this IIP6Config o) => o.GetAsync<IDictionary<string, object>[]>("AddressData");
        public static Task<string> GetGatewayAsync(this IIP6Config o) => o.GetAsync<string>("Gateway");
        public static Task<(byte[], uint, byte[], uint)[]> GetRoutesAsync(this IIP6Config o) => o.GetAsync<(byte[], uint, byte[], uint)[]>("Routes");
        public static Task<IDictionary<string, object>[]> GetRouteDataAsync(this IIP6Config o) => o.GetAsync<IDictionary<string, object>[]>("RouteData");
        public static Task<byte[][]> GetNameserversAsync(this IIP6Config o) => o.GetAsync<byte[][]>("Nameservers");
        public static Task<string[]> GetDomainsAsync(this IIP6Config o) => o.GetAsync<string[]>("Domains");
        public static Task<string[]> GetSearchesAsync(this IIP6Config o) => o.GetAsync<string[]>("Searches");
        public static Task<string[]> GetDnsOptionsAsync(this IIP6Config o) => o.GetAsync<string[]>("DnsOptions");
        public static Task<int> GetDnsPriorityAsync(this IIP6Config o) => o.GetAsync<int>("DnsPriority");
    }

    [DBusInterface("org.freedesktop.NetworkManager.DnsManager")]
    interface IDnsManager : IDBusObject
    {
        Task<T> GetAsync<T>(string prop);
        Task<DnsManagerProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class DnsManagerProperties
    {
        private string _Mode = default(string);
        public string Mode
        {
            get
            {
                return _Mode;
            }

            set
            {
                _Mode = (value);
            }
        }

        private string _RcManager = default(string);
        public string RcManager
        {
            get
            {
                return _RcManager;
            }

            set
            {
                _RcManager = (value);
            }
        }

        private IDictionary<string, object>[] _Configuration = default(IDictionary<string, object>[]);
        public IDictionary<string, object>[] Configuration
        {
            get
            {
                return _Configuration;
            }

            set
            {
                _Configuration = (value);
            }
        }
    }

    static class DnsManagerExtensions
    {
        public static Task<string> GetModeAsync(this IDnsManager o) => o.GetAsync<string>("Mode");
        public static Task<string> GetRcManagerAsync(this IDnsManager o) => o.GetAsync<string>("RcManager");
        public static Task<IDictionary<string, object>[]> GetConfigurationAsync(this IDnsManager o) => o.GetAsync<IDictionary<string, object>[]>("Configuration");
    }

    [DBusInterface("org.freedesktop.NetworkManager.IP4Config")]
    interface IIP4Config : IDBusObject
    {
        Task<IDisposable> WatchPropertiesChangedAsync(Action<IDictionary<string, object>> handler, Action<Exception> onError = null);
        Task<T> GetAsync<T>(string prop);
        Task<IP4ConfigProperties> GetAllAsync();
        Task SetAsync(string prop, object val);
        Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
    }

    [Dictionary]
    class IP4ConfigProperties
    {
        private uint[][] _Addresses = default(uint[][]);
        public uint[][] Addresses
        {
            get
            {
                return _Addresses;
            }

            set
            {
                _Addresses = (value);
            }
        }

        private IDictionary<string, object>[] _AddressData = default(IDictionary<string, object>[]);
        public IDictionary<string, object>[] AddressData
        {
            get
            {
                return _AddressData;
            }

            set
            {
                _AddressData = (value);
            }
        }

        private string _Gateway = default(string);
        public string Gateway
        {
            get
            {
                return _Gateway;
            }

            set
            {
                _Gateway = (value);
            }
        }

        private uint[][] _Routes = default(uint[][]);
        public uint[][] Routes
        {
            get
            {
                return _Routes;
            }

            set
            {
                _Routes = (value);
            }
        }

        private IDictionary<string, object>[] _RouteData = default(IDictionary<string, object>[]);
        public IDictionary<string, object>[] RouteData
        {
            get
            {
                return _RouteData;
            }

            set
            {
                _RouteData = (value);
            }
        }

        private IDictionary<string, object>[] _NameserverData = default(IDictionary<string, object>[]);
        public IDictionary<string, object>[] NameserverData
        {
            get
            {
                return _NameserverData;
            }

            set
            {
                _NameserverData = (value);
            }
        }

        private uint[] _Nameservers = default(uint[]);
        public uint[] Nameservers
        {
            get
            {
                return _Nameservers;
            }

            set
            {
                _Nameservers = (value);
            }
        }

        private string[] _Domains = default(string[]);
        public string[] Domains
        {
            get
            {
                return _Domains;
            }

            set
            {
                _Domains = (value);
            }
        }

        private string[] _Searches = default(string[]);
        public string[] Searches
        {
            get
            {
                return _Searches;
            }

            set
            {
                _Searches = (value);
            }
        }

        private string[] _DnsOptions = default(string[]);
        public string[] DnsOptions
        {
            get
            {
                return _DnsOptions;
            }

            set
            {
                _DnsOptions = (value);
            }
        }

        private int _DnsPriority = default(int);
        public int DnsPriority
        {
            get
            {
                return _DnsPriority;
            }

            set
            {
                _DnsPriority = (value);
            }
        }

        private string[] _WinsServerData = default(string[]);
        public string[] WinsServerData
        {
            get
            {
                return _WinsServerData;
            }

            set
            {
                _WinsServerData = (value);
            }
        }

        private uint[] _WinsServers = default(uint[]);
        public uint[] WinsServers
        {
            get
            {
                return _WinsServers;
            }

            set
            {
                _WinsServers = (value);
            }
        }
    }

    static class IP4ConfigExtensions
    {
        public static Task<uint[][]> GetAddressesAsync(this IIP4Config o) => o.GetAsync<uint[][]>("Addresses");
        public static Task<IDictionary<string, object>[]> GetAddressDataAsync(this IIP4Config o) => o.GetAsync<IDictionary<string, object>[]>("AddressData");
        public static Task<string> GetGatewayAsync(this IIP4Config o) => o.GetAsync<string>("Gateway");
        public static Task<uint[][]> GetRoutesAsync(this IIP4Config o) => o.GetAsync<uint[][]>("Routes");
        public static Task<IDictionary<string, object>[]> GetRouteDataAsync(this IIP4Config o) => o.GetAsync<IDictionary<string, object>[]>("RouteData");
        public static Task<IDictionary<string, object>[]> GetNameserverDataAsync(this IIP4Config o) => o.GetAsync<IDictionary<string, object>[]>("NameserverData");
        public static Task<uint[]> GetNameserversAsync(this IIP4Config o) => o.GetAsync<uint[]>("Nameservers");
        public static Task<string[]> GetDomainsAsync(this IIP4Config o) => o.GetAsync<string[]>("Domains");
        public static Task<string[]> GetSearchesAsync(this IIP4Config o) => o.GetAsync<string[]>("Searches");
        public static Task<string[]> GetDnsOptionsAsync(this IIP4Config o) => o.GetAsync<string[]>("DnsOptions");
        public static Task<int> GetDnsPriorityAsync(this IIP4Config o) => o.GetAsync<int>("DnsPriority");
        public static Task<string[]> GetWinsServerDataAsync(this IIP4Config o) => o.GetAsync<string[]>("WinsServerData");
        public static Task<uint[]> GetWinsServersAsync(this IIP4Config o) => o.GetAsync<uint[]>("WinsServers");
    }
}