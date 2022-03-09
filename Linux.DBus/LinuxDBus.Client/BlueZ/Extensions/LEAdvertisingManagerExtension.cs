using System.Threading.Tasks;
using LinuxDbus.Bluetooth.BlueZ.Interfaces;

namespace LinuxDbus.Bluetooth.BlueZ.Extensions
{
  public static class LEAdvertisingManagerExtension
  {
    public static Task<byte> GetActiveInstancesAsync(this ILEAdvertisingManager o) => o.GetAsync<byte>("ActiveInstances");

    public static Task<byte> GetSupportedInstancesAsync(this ILEAdvertisingManager o) => o.GetAsync<byte>("SupportedInstances");

    public static Task<string[]> GetSupportedIncludesAsync(this ILEAdvertisingManager o) => o.GetAsync<string[]>("SupportedIncludes");
  }
}
