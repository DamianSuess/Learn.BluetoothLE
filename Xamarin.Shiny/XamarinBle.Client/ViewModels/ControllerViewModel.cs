using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using XamarinHelloBle.Client.Services;

namespace XamarinHelloBle.Client.ViewModels
{
  public class ControllerViewModel : ViewModelBase
  {
    //// private readonly BluetoothService _ble;

    public ControllerViewModel(INavigationService nav) //// , BluetoothService ble)
      : base(nav)
    {
      Title = "Remote Control";
      //// _ble = ble;
    }

    public DelegateCommand CmdToggleLed => new DelegateCommand(async () =>
    {
      // Send command to toggle on-board LED
      await Task.Yield();
    });
  }
}
