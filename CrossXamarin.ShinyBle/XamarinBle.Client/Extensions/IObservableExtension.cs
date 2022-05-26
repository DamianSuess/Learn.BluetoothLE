using System;
using Xamarin.Forms;

namespace XamarinHelloBle.Client.Extensions
{
  public static class IObservableExtension
  {
    public static IDisposable SubscribeOnThread<T>(this IObservable<T> observable, Action<T> onAction)
    {
      return observable.Subscribe(x =>
        Device.BeginInvokeOnMainThread(() =>
          onAction(x)));
    }

    public static IDisposable SubscribeOnThread<T>(this IObservable<T> observable, Action<T> onAction, Action<Exception> onError)
    {
      return observable.Subscribe(
        x => Device.BeginInvokeOnMainThread(() => onAction(x)),
        onError);
    }

    public static IDisposable SubscribeOnThread<T>(this IObservable<T> observable, Action<T> onAction, Action<Exception> onError, Action onComplete)
    {
      return observable.Subscribe(
        x => Device.BeginInvokeOnMainThread(() => onAction(x)),
        onError,
        onComplete);
    }
  }
}
