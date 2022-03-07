using System.Collections.Generic;
using System.Threading.Tasks;
using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces
{
  [DBusInterface(Constants.ProfileManager)]
  public interface IProfileManager : IDBusObject
  {
    Task RegisterProfileAsync(ObjectPath profile, string uuid, IDictionary<string, object> options);

    Task UnregisterProfileAsync(ObjectPath profile);
  }
}
