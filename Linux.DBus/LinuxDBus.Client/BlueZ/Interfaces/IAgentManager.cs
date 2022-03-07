using System.Threading.Tasks;
using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces;

[DBusInterface(Constants.AgentManager)]
public interface IAgentManager : IDBusObject
{
  Task RegisterAgentAsync(ObjectPath agent, string capability);

  Task UnregisterAgentAsync(ObjectPath agent);
}
