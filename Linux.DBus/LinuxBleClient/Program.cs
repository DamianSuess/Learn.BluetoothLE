using Plugin.BlueZ;
using Plugin.BlueZ.Extensions;

class Program
{
  private static readonly string DefaultAdapter = "hci0";

  private static IReadOnlyList<Device> _devices;

  public static async Task Main(string[] args)
  {

    Console.WriteLine("Plugin.BlueZ - Test Client");
    Console.WriteLine("Press any <enter> to get started...");
    Console.ReadLine();

    // Get adapter
    var adapter = (await BlueZManager.GetAdaptersAsync()).FirstOrDefault();
    var adapter0 = await BlueZManager.GetAdapterAsync(DefaultAdapter);

    if (adapter is null)
    {
      Console.WriteLine("No BLE adapter found.");
      return;
    }

    // List known devices
    var devices = await adapter.GetDevicesAsync();
    foreach (var d in devices)
    {
      var name = d.GetNameAsync();

      // Device Description from Properties
      var properties = await d.GetAllAsync();
      var desc = $"{properties.Alias} (ADDR: {properties.Address}, RSSI: {properties.RSSI})";

      Console.WriteLine($"-- Known: '{name}' - '{desc}'");
    }

    // Scan
    adapter.DeviceFound += OnDeviceFoundAsync;
    await adapter.StartDiscoveryAsync();
  }

  private static async Task OnDeviceFoundAsync(Adapter sender, DeviceFoundEventArgs eventArgs)
  {
    var name = await eventArgs.Device.GetNameAsync();
    var isStateChanged = eventArgs.IsStateChange;

    Console.WriteLine($"** FOUND: '{name}' - isStateChanged: {isStateChanged}");

  }
}
