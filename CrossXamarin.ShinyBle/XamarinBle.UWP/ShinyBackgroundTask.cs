using Shiny;
using Windows.ApplicationModel.Background;

namespace XamarinHelloBle.UWP
{
  public class ShinyBackgroundTask : IBackgroundTask
  {
    public void Run(IBackgroundTaskInstance taskInstance) =>
      this.ShinyRunBackgroundTask(taskInstance, new Client.Startup());
  }
}
