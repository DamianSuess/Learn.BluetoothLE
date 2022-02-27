using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Shiny.BluetoothLE;

namespace XamarinHelloBle.Client.ViewModels
{
  public class ScannerViewModel : ViewModelBase
  {
    private bool _canControlAdapterState;
    private bool _isScanning;

    ////private PeripheralItemViewModel? _selectedPeripheral;
    private PeripheralItemViewModel _selectedPeripheral;

    public ScannerViewModel(INavigationService navService)
      : base(navService)
    {
      Title = "Select Host Device";

      IsScanning = false;

      var ble = Shiny.ShinyHost.Resolve<IBleManager>();
      IsScanning = ble?.IsScanning ?? false;
      CanControlAdapterState = ble?.CanControlAdapterState() ?? false;

      SelectedPeripheral = null;
    }

    public bool CanControlAdapterState
    {
      get => _canControlAdapterState;
      set => SetProperty(ref _canControlAdapterState, value);
    }

    public DelegateCommand CmdScan => new DelegateCommand(async () =>
    {
      if (IsScanning)
        await ScanStartAsync();
      else
        await ScanStopAsync();
    });

    public DelegateCommand CmdToggleAdapterState => new DelegateCommand(async () =>
    {
      // Turn BLE adapter on/off
      await Task.Yield();
    });

    public bool IsScanning
    {
      get => _isScanning;
      set => SetProperty(ref _isScanning, value);
    }

    public ObservableCollection<PeripheralItemViewModel> Peripherals { get; }

    public PeripheralItemViewModel SelectedPeripheral
    {
      get => _selectedPeripheral;
      set => SetProperty(ref _selectedPeripheral, value);
    }

    public async void DeviceItemTappedAsync()
    {
      await Task.Yield();
      throw new NotImplementedException();
    }

    private async Task ScanStartAsync()
    {
      await Task.Yield();
      //// var scanner = CrossBleAdapter
      throw new NotImplementedException();
    }

    private async Task ScanStopAsync()
    {
      await Task.Yield();
      throw new NotImplementedException();
    }
  }
}
