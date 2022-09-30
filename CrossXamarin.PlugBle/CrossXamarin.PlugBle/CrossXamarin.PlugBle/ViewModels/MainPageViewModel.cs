using System;
using System.Collections.ObjectModel;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using Prism.Commands;
using Prism.Navigation;

namespace CrossXamarin.PlugBle.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    private readonly IBluetoothLE _ble;
    private ObservableCollection<string> _bleDevices = new ObservableCollection<string>();
    private string _message = "";
    private string _bleAdapterState = "";
    private string _bleDeviceSelected = "";

    public MainPageViewModel(INavigationService navigationService, IBluetoothLE ble)
      : base(navigationService)
    {
      _ble = ble;
      Title = "Main Page";
    }

    public ObservableCollection<string> Devices
    {
      get => _bleDevices;
      set => SetProperty(ref _bleDevices, value);
    }

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public string BleAdapterState
    {
      get => _bleAdapterState;
      set => SetProperty(ref _bleAdapterState, value);
    }

    public string BleDeviceSelected
    {
      get => _bleDeviceSelected;
      set => SetProperty(ref _bleDeviceSelected, value);
    }

    private DelegateCommand CmdScanStart => new DelegateCommand(async () =>
    {
      if (_ble.Adapter.IsScanning)
        return;

      Devices.Clear();
      foreach (var d in _ble.Adapter.DiscoveredDevices)
      {
        Devices.Add($"{d.Id};{d.Name}");
      }

      await _ble.Adapter.StartScanningForDevicesAsync();
    });

    private DelegateCommand CmdScanStop => new DelegateCommand(async () =>
    {
      if (!_ble.Adapter.IsScanning)
        return;

      await _ble.Adapter.StopScanningForDevicesAsync();
    });

    private DelegateCommand CmdConnect => new DelegateCommand(async () =>
    {
      ;
    });

    private DelegateCommand CmdDisconnect => new DelegateCommand(async () =>
    {
      ;
    });

    private DelegateCommand CmdSend => new DelegateCommand(async () =>
    {
      ;
    });

    public override void OnNavigatedTo(INavigationParameters parameters)
    {
      RegisterEvents(true);
    }

    public override void OnNavigatedFrom(INavigationParameters parameters)
    {
      RegisterEvents(false);
    }

    private void Bluetooth_StateChanged(object sender, Plugin.BLE.Abstractions.EventArgs.BluetoothStateChangedArgs e)
    {
      BleAdapterState = e.NewState.ToString();
    }

    private void RegisterEvents(bool register)
    {
      _ble.StateChanged -= Bluetooth_StateChanged;
      _ble.Adapter.DeviceConnected -= Bluetooth_DeviceConnected;
      _ble.Adapter.DeviceConnectionLost -= Bluetooth_DeviceConnectionLost;
      _ble.Adapter.DeviceDiscovered -= Bluetooth_DeviceDiscovered;
      _ble.Adapter.DeviceDisconnected -= Bluetooth_DeviceDisconnected;
      _ble.Adapter.ScanTimeoutElapsed -= Bluetooth_ScanTimeoutElapsed;

      if (register)
      {
        _ble.StateChanged += Bluetooth_StateChanged;
        _ble.Adapter.DeviceAdvertised += Bluetooth_DeviceAdvertised;
        _ble.Adapter.DeviceConnected += Bluetooth_DeviceConnected;
        _ble.Adapter.DeviceConnectionLost += Bluetooth_DeviceConnectionLost;
        _ble.Adapter.DeviceDiscovered += Bluetooth_DeviceDiscovered;
        _ble.Adapter.DeviceDisconnected += Bluetooth_DeviceDisconnected;
        _ble.Adapter.ScanTimeoutElapsed += Bluetooth_ScanTimeoutElapsed;
      }
    }

    private void Bluetooth_DeviceAdvertised(object sender, DeviceEventArgs e)
    {
      Console.WriteLine($"Device Advertised: {e.Device.Id};{e.Device.Name}");
    }

    private void Bluetooth_ScanTimeoutElapsed(object sender, EventArgs e)
    {
    }

    private void Bluetooth_DeviceConnectionLost(object sender, DeviceErrorEventArgs e)
    {
      BleAdapterState = "Connection Lost";
    }

    private void Bluetooth_DeviceDisconnected(object sender, DeviceEventArgs e)
    {
      BleAdapterState = "Disconnected";
    }

    private void Bluetooth_DeviceConnected(object sender, DeviceEventArgs e)
    {
      BleAdapterState = "Connected";
    }

    private void Bluetooth_DeviceDiscovered(object sender, DeviceEventArgs e)
    {
      Devices.Add($"{e.Device.Id};{e.Device.Name}");
    }
  }
}