using System;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using XamarinHelloBle.Client.ViewModels;
using XamarinHelloBle.Client.Views;

namespace XamarinHelloBle.Client
{
  /// <summary>Client entry.</summary>
  public partial class App
  {
    public App(IPlatformInitializer initializer)
      : base(initializer)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      //// var ret = await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainView)}/{nameof(ScannerView)}");
      var ret = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(ControllerView)}");
      if (!ret.Success)
      {
        Console.WriteLine($"Error! {ret.Exception.Message}");
      }
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
      //// containerRegistry.RegisterSingleton<IBleManager, ShinyBle>();
      //// containerRegistry.RegisterSingleton<BluetoothService>();

      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
      //// containerRegistry.RegisterForNavigation<ScannerView, ScannerViewModel>();
      containerRegistry.RegisterForNavigation<ControllerView, ControllerViewModel>();
    }
  }
}
