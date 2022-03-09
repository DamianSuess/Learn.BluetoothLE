using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces
{
  [DBusInterface(Constants.GattManager)]
  public interface IGattManager : IDBusObject
  {
    Task RegisterApplicationAsync(ObjectPath application, IDictionary<string, object> options);

    Task UnregisterApplicationAsync(ObjectPath application);
  }
}
