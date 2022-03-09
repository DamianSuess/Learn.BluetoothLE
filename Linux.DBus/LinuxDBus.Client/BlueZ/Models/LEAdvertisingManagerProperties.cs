namespace LinuxDbus.Bluetooth.BlueZ.Models
{
  public class LEAdvertisingManagerProperties
  {
    public LEAdvertisingManagerProperties()
    {
    }

    public byte ActiveInstances { get; set; } = default;

    public byte SupportedInstances { get; set; } = default;

    public string[] SupportedIncludes { get; set; } = default;
  }
}
