using Prism.Navigation;

namespace XamarinHelloBle.Client.ViewModels
{
  public class MainTabbedViewModel : ViewModelBase
  {
    public MainTabbedViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";
    }

    public override void OnNavigatedTo(INavigationParameters parameters)
    {
      base.OnNavigatedTo(parameters);
    }
  }
}
