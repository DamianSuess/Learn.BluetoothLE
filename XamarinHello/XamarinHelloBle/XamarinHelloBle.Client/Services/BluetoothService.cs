using System.Threading.Tasks;
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

    public void StartScanning()
    {
    }

    public async Task StopScanningAsync()
    {
      await Task.Yield();
    }
  }
}
