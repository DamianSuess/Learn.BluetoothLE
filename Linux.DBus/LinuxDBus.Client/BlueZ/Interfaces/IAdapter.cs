using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces
{
  [DBusInterface(Constants.AdapterInterface)]
  public interface IAdapter : IDBusObject
  {
    Task StartDiscoveryAsync();

    Task SetDiscoveryFilterAsync(IDictionary<string, object> properties);

    Task StopDiscoveryAsync();

    Task RemoveDeviceAsync(ObjectPath device);

    Task<string[]> GetDiscoveryFilterAsync();

    Task<T> GetAsync<T>(string property);

    Task<AdapterProperties> GetAllAync();

    Task SetAsync(string property, object value);

    Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
  }
}
