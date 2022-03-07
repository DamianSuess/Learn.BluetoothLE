namespace LinuxDbus.Bluetooth.BlueZ.Events
{
  public class DeviceFoundEventArgs : BlueZEventArgs
  {
    public DeviceFoundEventArgs(Device device, bool stateChanged = true)
      : base(stateChanged)
    {
      Device = device;
    }

    public Device Device { get; }
  }
}
