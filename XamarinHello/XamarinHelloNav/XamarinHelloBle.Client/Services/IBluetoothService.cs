using System.Threading.Tasks;

namespace XamarinHelloBle.Client.Services
{
  public interface IBluetoothService
  {
    bool CanControlAdapterState { get; }

    bool IsConnected { get; }

    void RefreshManager();

    Task StartScanAsync();

    void StopScan();

    Task ToggleAdapterAsync();
  }
}
