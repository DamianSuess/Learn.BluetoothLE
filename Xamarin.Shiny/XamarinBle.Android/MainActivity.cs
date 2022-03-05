using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Shiny;

////[assembly: Shiny.ShinyApplication(
////  ShinyStartupTypeName = "XamarinHelloBle.Client.Startup",
////  XamarinFormsAppTypeName = "XamarinHelloBle.Client.App")]

namespace XamarinHelloBle.Droid
{
  public class AndroidInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }

  /// <summary>I don't care to document.</summary>
  [Activity(Theme = "@style/MainTheme",
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
  public partial class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
    {
      this.ShinyOnRequestPermissionsResult(requestCode, permissions, grantResults);
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
      base.OnActivityResult(requestCode, resultCode, data);
      this.ShinyOnActivityResult(requestCode, resultCode, data);
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
      this.ShinyOnCreate();

      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);

      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
      LoadApplication(new Client.App(new AndroidInitializer()));
    }

    protected override void OnNewIntent(Intent intent)
    {
      base.OnNewIntent(intent);
      this.ShinyOnNewIntent(intent);
      Xamarin.Essentials.Platform.OnNewIntent(intent);
    }
  }
}
