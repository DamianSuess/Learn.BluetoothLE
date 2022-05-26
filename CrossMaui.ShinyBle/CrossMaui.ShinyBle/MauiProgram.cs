using Prism;
using Prism.DryIoc.Maui;

namespace CrossMaui.ShinyBle;

// References:
//  - https://github.com/dansiegel/Prism.Maui
//  - https://www.nuget.org/packages/Prism.Maui/
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
    return MauiApp.CreateBuilder()
      .UsePrismApp<App>()
      .RegisterTypes(containerRegistry =>
      {
        containerRegistry.RegisterGlobalNavigationObserver();
        containerRegistry.RegisterForNavigation<MainPage>();
        containerRegistry.RegisterForNavigation<RootPage>();
        containerRegistry.RegisterForNavigation<SamplePage>();
      })
      .OnAppStart
      ////.OnAppStart(navigationService => navigationService.CreateBuilder()
      ////  .AddNavigationSegment("MainPage")
      ////  .AddNavigationPage()
      ////  .AddNavigationSegment<ViewAViewModel>()
      ////  .AddNavigationSegment("ViewB")
      ////  .Navigate(HandleNavigationError))
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
      })
      .Build();

    ////var builder = MauiApp.CreateBuilder()
    ////  .UseMauiApp<App>()
    ////	.ConfigureFonts(fonts =>
    ////	{
    ////		fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
    ////		fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
    ////	});
    ////
    ////return builder.Build();
  }

  private static void HandleNavigationError(Exception ex)
  {
    Console.WriteLine(ex);
    System.Diagnostics.Debugger.Break();
  }
}
