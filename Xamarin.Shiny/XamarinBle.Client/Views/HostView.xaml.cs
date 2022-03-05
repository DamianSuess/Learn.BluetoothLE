using Prism.Commands;
using Shiny.BluetoothLE;
using Shiny.BluetoothLE.Hosting;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloBle.Client.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HostView : ContentPage
  {
    private const string Characteristic1Uuid = "A495FF21-C5B1-4B44-B512-1370F02D74DE";
    private const string Characteristic2Uuid = "A495FF22-C5B1-4B44-B512-1370F02D74DE";
    private const string ServiceUuid = "A495FF20-C5B1-4B44-B512-1370F02D74DE";
    private readonly IBleManager _ble;
    private readonly IBleHostingManager _host;

    public HostView()
    {
      InitializeComponent();

      _ble = Shiny.ShinyHost.Resolve<IBleManager>();
    }

    DelegateCommand CmdSetup => new DelegateCommand(OnConfigure);

    private void OnConfigure()
    {
      var service = _host
    }
  }
}
