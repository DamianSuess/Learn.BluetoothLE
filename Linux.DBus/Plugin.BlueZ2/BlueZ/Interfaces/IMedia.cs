using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces
{
  [DBusInterface(Constants.MediaInterface)]
  public interface IMedia : IDBusObject
  {
    Task RegisterEndpointAsync(ObjectPath endpoint, IDictionary<string, object> properties);

    Task UnregisterEndpointAsync(ObjectPath endpoint);

    Task RegisterPlayerAsync(ObjectPath player, IDictionary<string, object> properties);

    Task UnregisterPlayerAsync(ObjectPath player);
  }
}
