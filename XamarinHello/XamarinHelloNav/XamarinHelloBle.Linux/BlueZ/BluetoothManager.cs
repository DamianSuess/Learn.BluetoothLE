using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinHelloBle.Linux.BlueZ
{
  public static class BluetoothManager
  {
    public static async Task<Adapter> GetAdapterAsync(string adapterName)
    {
      throw new NotImplementedException();
    }

    public static async Task<IReadOnlyList<Adapter>> GetAdaptersAsync()
    {
      throw new NotImplementedException();
    }

    public static string NormalizeUuid(string uuid)
    {
      throw new NotImplementedException();
    }

    public static bool IsMatch()
    {
      throw new NotImplementedException();
    }

    public static bool IsMatch(string interfaceName)
    {
      throw new NotImplementedException();
    }
  }
}
