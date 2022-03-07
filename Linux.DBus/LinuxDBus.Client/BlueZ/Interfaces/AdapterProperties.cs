using Tmds.DBus;

namespace LinuxDbus.Bluetooth.BlueZ.Interfaces
{
  [Dictionary]
  public class AdapterProperties
  {
    public AdapterProperties()
    {
      Address = default(string);
      AddressType = default(string);
      Name = default(string);
      Alias = default(string);
      Class = default(uint);
      Powered = default(bool);
      Discoverable = default(bool);
      DiscoverableTimeout = default(uint);
      Pairable = default(bool);
      PairableTimeout = default(uint);
      Discovering = default(bool);
      UUIDs = default(string[]);
      Modalias = default(string);
    }

    public string Address { get; set; }

    public string AddressType { get; set; }

    public string Name { get; set; }

    public string Alias { get; set; }

    public uint Class { get; set; }

    public bool Powered { get; set; }

    public bool Discoverable { get; set; }

    public uint DiscoverableTimeout { get; set; }

    public bool Pairable { get; set; }

    public uint PairableTimeout { get; set; }

    public bool Discovering { get; set; }

    public string[] UUIDs { get; set; }

    public string Modalias { get; set; }
  }
}
