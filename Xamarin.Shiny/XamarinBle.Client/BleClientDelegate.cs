using System;
using System.Threading.Tasks;
using Shiny;
using Shiny.BluetoothLE;
using Shiny.Notifications;

namespace XamarinHelloBle.Client
{
  public class BleClientDelegate : BleDelegate
  {
    //// private readonly SampleSqliteConnection _sql;
    private readonly INotificationManager _notifications;

    public BleClientDelegate(INotificationManager notificationManager)
    {
      // _sql = conn;
      _notifications = notificationManager;
    }

    public override async Task OnAdapterStateChanged(AccessState state)
    {
      Console.WriteLine($"BLE Client - State Changed {state}");

      if (state == AccessState.Disabled)
        await _notifications.Send("BLE State", "Turn on Bluetooth already");
    }

    public override async Task OnConnected(IPeripheral peripheral)
    {
      Console.WriteLine("OnConnected to Peripheral!");

      await Task.Yield();

      ////await this.services.Connection.InsertAsync(new BleEvent
      ////{
      ////    Description = $"Peripheral '{peripheral.Name}' Connected",
      ////    Timestamp = DateTime.Now
      ////});
      ////await this.services.Notifications.Send(
      ////    this.GetType(),
      ////    true,
      ////    "BluetoothLE Device Connected",
      ////    $"{peripheral.Name} has connected"
      ////);
    }
  }
}
