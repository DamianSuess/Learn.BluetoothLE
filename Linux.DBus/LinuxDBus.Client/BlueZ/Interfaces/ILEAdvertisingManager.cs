using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinuxDbus.Bluetooth.BlueZ.Models;
using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces
{
  [DBusInterface(Constants.LeAdvertisingManager)]
  public interface ILEAdvertisingManager : IDBusObject
  {
    Task RegisterAdvertisementAsync(ObjectPath advertisement, IDictionary<string, object> options);

    Task UnregisterAdvertisementAsync(ObjectPath service);

    Task<T> GetAsync<T>(string prop);

    Task<LEAdvertisingManagerProperties> GetAllAsync();

    Task SetAsync(string prop, object val);

    Task<IDisposable> WatchPropertiesAsync(Action<PropertyChanges> handler);
  }
}
