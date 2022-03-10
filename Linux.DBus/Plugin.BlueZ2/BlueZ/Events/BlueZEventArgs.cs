using System;

namespace LinuxDbus.Bluetooth.BlueZ.Events
{
  public class BlueZEventArgs : EventArgs
  {
    public BlueZEventArgs(bool stateChanged = true)
    {
      StateChanged = stateChanged;
    }

    public bool StateChanged { get; }
  }
}
