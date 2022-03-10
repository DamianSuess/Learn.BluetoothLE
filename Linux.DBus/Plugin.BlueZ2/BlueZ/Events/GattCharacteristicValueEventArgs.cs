using System;

namespace LinuxDbus.Bluetooth.BlueZ.Events
{
  public class GattCharacteristicValueEventArgs : EventArgs
  {
    public GattCharacteristicValueEventArgs(byte[] value)
    {
      Value = value;
    }

    public byte[] Value { get; }
  }
}
