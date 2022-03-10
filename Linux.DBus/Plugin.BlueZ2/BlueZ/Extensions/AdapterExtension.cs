using System.Threading.Tasks;
using LinuxDbus.Bluetooth.BlueZ.Interfaces;

namespace LinuxDbus.Bluetooth.BlueZ.Extensions
{
  public static class AdapterExtension
  {
    public static Task<string> GetAddressAsync(this IAdapter o) => o.GetAsync<string>("Address");

    public static Task<string> GetAddressTypeAsync(this IAdapter o) => o.GetAsync<string>("AddressType");

    public static Task<string> GetNameAsync(this IAdapter o) => o.GetAsync<string>("Name");

    public static Task<string> GetAliasAsync(this IAdapter o) => o.GetAsync<string>("Alias");

    public static Task<uint> GetClassAsync(this IAdapter o) => o.GetAsync<uint>("Class");

    public static Task<bool> GetPoweredAsync(this IAdapter o) => o.GetAsync<bool>("Powered");

    public static Task<bool> GetDiscoverableAsync(this IAdapter o) => o.GetAsync<bool>("Discoverable");

    public static Task<uint> GetDiscoverableTimeoutAsync(this IAdapter o) => o.GetAsync<uint>("DiscoverableTimeout");

    public static Task<bool> GetPairableAsync(this IAdapter o) => o.GetAsync<bool>("Pairable");

    public static Task<uint> GetPairableTimeoutAsync(this IAdapter o) => o.GetAsync<uint>("PairableTimeout");

    public static Task<bool> GetDiscoveringAsync(this IAdapter o) => o.GetAsync<bool>("Discovering");

    public static Task<string[]> GetUUIDsAsync(this IAdapter o) => o.GetAsync<string[]>("UUIDs");

    public static Task<string> GetModaliasAsync(this IAdapter o) => o.GetAsync<string>("Modalias");

    public static Task SetAliasAsync(this IAdapter o, string val) => o.SetAsync("Alias", val);

    public static Task SetPoweredAsync(this IAdapter o, bool val) => o.SetAsync("Powered", val);

    public static Task SetDiscoverableAsync(this IAdapter o, bool val) => o.SetAsync("Discoverable", val);

    public static Task SetDiscoverableTimeoutAsync(this IAdapter o, uint val) => o.SetAsync("DiscoverableTimeout", val);

    public static Task SetPairableAsync(this IAdapter o, bool val) => o.SetAsync("Pairable", val);

    public static Task SetPairableTimeoutAsync(this IAdapter o, uint val) => o.SetAsync("PairableTimeout", val);
  }
}
