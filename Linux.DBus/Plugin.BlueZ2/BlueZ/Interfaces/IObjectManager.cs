using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces
{
  [DBusInterface(Constants.ObjectManager)]
  public interface IObjectManager : IDBusObject
  {
    Task<IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>>> GetManagedObjectsAsync();

    Task<IDisposable> WatchInterfacesAddedAsync(Action<(ObjectPath obj, IDictionary<string, IDictionary<string, object>> interfaces)> handler, Action<Exception> onError = null);

    Task<IDisposable> WatchInterfacesRemovedAsync(Action<(ObjectPath obj, string[] interfaces)> handler, Action<Exception> onError = null);
  }
}
