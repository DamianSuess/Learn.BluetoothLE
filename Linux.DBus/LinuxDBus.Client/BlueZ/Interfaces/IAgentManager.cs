using System.Threading.Tasks;
using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces;

[DBusInterface(Constants.AgentManager)]
public interface IAgentManager : IDBusObject
{
  Task RegisterAgentAsync(ObjectPath agent, string capability);

  Task RequestDefaultAgentAsync(ObjectPath agent);

  Task UnregisterAgentAsync(ObjectPath agent);
}
