using System;
using Prism;
using Prism.Ioc;
using Shiny.BluetoothLE;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using XamarinHelloBle.Client.Services;
using XamarinHelloBle.Client.ViewModels;
using XamarinHelloBle.Client.Views;

namespace XamarinHelloBle.Client
{
  /// <summary>App.</summary>
  public partial class App
  {
    public App(IPlatformInitializer initializer)
      : base(initializer)
    {
    }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      //// ret = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainTabbedView)}");
      //// var ret = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(ControllerView)}");
      var ret = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(ScannerView)}");
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
      containerRegistry.RegisterForNavigation<MainTabbedView, MainTabbedViewModel>();
      containerRegistry.RegisterForNavigation<ScannerView, ScannerViewModel>();
      containerRegistry.RegisterForNavigation<ControllerView, ControllerViewModel>();
    }
  }
}
