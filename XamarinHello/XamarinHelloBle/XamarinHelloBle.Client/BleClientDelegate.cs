using System.Threading.Tasks;
using Shiny;
using Shiny.BluetoothLE;
using Shiny.Notifications;

namespace XamarinHelloBle.Client
{
  public class BleClientDelegate : BleDelegate
  {
    // readonly SampleSqliteConnection conn;
    private readonly INotificationManager _notifications;

    public BleClientDelegate(INotificationManager notificationManager)
    {
      // this.conn = conn;
      _notifications = notificationManager;
    }

    public override async Task OnAdapterStateChanged(AccessState state)
    {
      if (state == AccessState.Disabled)
        await _notifications.Send("BLE State", "Turn on Bluetooth already");
    }

    public override async Task OnConnected(IPeripheral peripheral)
    {
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
