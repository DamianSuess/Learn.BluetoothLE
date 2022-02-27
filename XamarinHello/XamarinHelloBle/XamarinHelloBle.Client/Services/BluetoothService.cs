using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Shiny;
using Shiny.BluetoothLE;

namespace XamarinHelloBle.Client.Services
{
  public class BluetoothService
  {
    private IBleManager _ble;

    public BluetoothService()
    {
      RefreshManager();
    }

    public bool CanControlAdapterState => _ble?.CanControlAdapterState() ?? false;

    /// <summary>Gets a value indicating whether or not we're connected to remote device host.</summary>
    public bool IsConnected => false;

    public bool IsScanning => _ble?.IsScanning ?? false;

    public void RefreshManager()
    {
      _ble = Shiny.ShinyHost.Resolve<IBleManager>();
    }

    public async Task StartScanAsync()
    {
      if (_ble == null)
      {
        Console.WriteLine("BLE not supported on this platform.");
        return;
      }

      await Task.Yield();

      throw new NotImplementedException();
    }

    public void StopScan()
    {
      throw new NotImplementedException();
      //// _scanSubscription?.Dispose();
      //// _scanSubscription = null;
      //// IsScanning = false;
    }

    public async Task ToggleAdapterAsync()
    {
      // Turn BLE adapter on/off
      if (_ble == null)
      {
        Console.WriteLine("BLE not supported on this platform!");
        return;
      }

      var status = await _ble.RequestAccess();
      if (status == AccessState.Available)
        await _ble.TrySetAdapterState(false);
      else
        await _ble.TrySetAdapterState(true);
    }
  }
}
