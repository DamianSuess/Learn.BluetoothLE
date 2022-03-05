using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;

namespace XamarinHelloBle.Client.ViewModels
{
  public class HostViewModel : ViewModelBase
  {
    public HostViewModel(INavigationService nav)
      : base(nav)
    {
      Title = "BLE Host";
    }
  }
}
