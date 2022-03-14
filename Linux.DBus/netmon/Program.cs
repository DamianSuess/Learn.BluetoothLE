using System;
using System.Threading.Tasks;
using Tmds.DBus;
using NetworkManager.DBus;

namespace DBusExample
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      Console.WriteLine("Monitoring network state changes. Press Ctrl-C to stop.");

      var systemConnection = Connection.System;
      var networkManager = systemConnection.CreateProxy<INetworkManager>(
        "org.freedesktop.NetworkManager", "/org/freedesktop/NetworkManager");

      foreach (var device in await networkManager.GetDevicesAsync())
      {
        var interfaceName = await device.GetInterfaceAsync();
        await device.WatchStateChangedAsync(
            change => Console.WriteLine($"{interfaceName}: {change.oldState} -> {change.newState}")
        );
      }

      Console.WriteLine("Exiting");
    }
  }
}