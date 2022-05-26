using Prism.Mvvm;
using Shiny.BluetoothLE;

namespace XamarinHelloBle.Client.ViewModels
{
  public class PeripheralItemViewModel : BindableBase
  {
    public PeripheralItemViewModel(IPeripheral perf)
    {
      Peripheral = perf;
    }

    public string IsConnectable { get; private set; }

    public bool IsConnected { get; private set; }

    public string LocalName { get; private set; }

    public string ManufacturerData { get; private set; }

    public string Name { get; private set; }

    public IPeripheral Peripheral { get; }

    public int Rssi { get; private set; }

    public int ServiceCount { get; private set; }

    public int TxPower { get; private set; }

    public string Uuid => Peripheral.Uuid;

    public override bool Equals(object obj) => Peripheral.Equals(obj);

    public override int GetHashCode() => Peripheral.GetHashCode();

    public void Update(ScanResult result)
    {
      Name = Peripheral.Name;
      Rssi = result.Rssi;

      var adv = result.AdvertisementData;
      ServiceCount = adv.ServiceUuids?.Length ?? 0;
      IsConnectable = adv?.IsConnectable?.ToString() ?? "Unknown";
      LocalName = adv.LocalName;
      TxPower = adv.TxPower ?? 0;

      // Is this correct?
      IsConnected = Peripheral.IsConnected();

      // TODO: Needs Tested
      //// ManufacturerData = adv.ManufacturerData == null
      ////   ? null : System.BitConverter.ToString(adv.ManufacturerData.Data);

      RaisePropertyChanged(string.Empty);
    }
  }
}
