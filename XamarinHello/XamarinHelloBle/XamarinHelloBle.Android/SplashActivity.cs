using Android.App;
using Android.Content;
using AndroidX.AppCompat.App;

namespace XamarinHelloBle.Droid
{
  [Activity(Theme = "@style/MainTheme.Splash",
            MainLauncher = true,
            NoHistory = true)]

  /// <summary>Splash screen.</summary>
  public partial class SplashActivity : AppCompatActivity
  {
    // Launches the startup task
    protected override void OnResume()
    {
      base.OnResume();
      StartActivity(new Intent(Application.Context, typeof(MainActivity)));
    }
  }
}
