using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Shiny;
using Shiny.BluetoothLE;
using Xamarin.Forms;

namespace XamarinHelloBle.Client.ViewModels
{
  public class ScannerViewModel : ViewModelBase
  {
    private IBleManager _ble;
    private bool _canControlAdapterState;
    private bool _isScanning;
    private IDisposable _scanSubscription;

    ////private PeripheralItemViewModel? _selectedPeripheral;
    private PeripheralItemViewModel _selectedPeripheral;

    public ScannerViewModel(INavigationService navService)
      : base(navService)
    {
      Title = "BLE Scanner";

      IsScanning = false;
      //// ShinyHost.Init(platform);

      _ble = Shiny.ShinyHost.Resolve<IBleManager>();

      IsScanning = _ble?.IsScanning ?? false;
      CanControlAdapterState = _ble?.CanControlAdapterState() ?? false;
      Peripherals = new ObservableCollection<PeripheralItemViewModel>();

      SelectedPeripheral = null;
    }

    public bool CanControlAdapterState
    {
      get => _canControlAdapterState;
      set => SetProperty(ref _canControlAdapterState, value);
    }

    public DelegateCommand CmdScan => new DelegateCommand(async () =>
    {
      if (!IsScanning)
        await ScanStartAsync();
      else
        ScanStop();
    });

    public DelegateCommand CmdToggleAdapterState => new DelegateCommand(async () =>
    {
      // Turn BLE adapter on/off
      if (_ble == null)
      {
        //// await Alert("Platform not supported!");
        Console.WriteLine("Platform not supported!");
        return;
      }

      if (!_ble.CanControlAdapterState())
      {
        Console.WriteLine("BLE: Cannot control adapter state.");
        return;
      }

      var ret = false;
      var btAccess = await _ble.RequestAccess();
      ret = btAccess == AccessState.Available ?
        await _ble.TrySetAdapterState(false) :
        await _ble.TrySetAdapterState(true);

      btAccess = await _ble.RequestAccess();

      Console.WriteLine($"BT: Toggle Adapter result: {ret}");
      Console.WriteLine($"BT: Adapter State: {btAccess}");
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
      set
      {
        SetProperty(ref _selectedPeripheral, value);

        // Why not use, `_ble.StopScan();`
        ScanStop();


      }
    }

    public async void DeviceItemTappedAsync()
    {
      await Task.Yield();
      throw new NotImplementedException();
    }

    private async Task ScanStartAsync()
    {
      if (_ble == null)
      {
        Console.WriteLine("BLE not supported on this platform.");
        return;
      }

      Peripherals.Clear();
      IsScanning = true;

      var devices = _ble
        .GetConnectedPeripherals()
        .Subscribe(peripherals => Device.BeginInvokeOnMainThread(() =>
        {
          foreach (var p in peripherals)
          {
            var vm = new PeripheralItemViewModel(p);
            Peripherals.Add(vm);
          }
        }));

      // TODO: Refactor this! Its an sample from Shiny and it appears inefficient
      _scanSubscription = _ble
        .Scan(null)
        .Buffer(TimeSpan.FromSeconds(1))
        .Where(x => x?.Any() ?? false)
        ////.SubscribeOnThread(results =>  //// <--- alt. using extension
        .Subscribe(results => Device.BeginInvokeOnMainThread(() =>
        {
          var list = new List<PeripheralItemViewModel>();

          foreach (var result in results)
          {
            var perf = Peripherals.FirstOrDefault(p => p.Equals(result.Peripheral));

            if (perf is null)
              perf = list.FirstOrDefault(p => p.Equals(result.Peripheral));

            if (perf != null)
            {
              perf.Update(result);
            }
            else
            {
              perf = new PeripheralItemViewModel(result.Peripheral);
              perf.Update(result);
              list.Add(perf);
            }

            if (list.Any())
            {
              // Xamarin.Forms is not able to deal with an
              // ObservableList or AddRange properly
              foreach (var item in list)
                Peripherals.Add(item);
            }
          }
        }),
        ex => Console.WriteLine(ex.ToString()));
    }

    private void ScanStop()
    {
      _scanSubscription?.Dispose();
      _scanSubscription = null;
      IsScanning = false;
    }
  }
}
