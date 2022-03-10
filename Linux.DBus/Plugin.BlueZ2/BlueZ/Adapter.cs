using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinuxDbus.Bluetooth.BlueZ.Events;

namespace LinuxDbus.Bluetooth.BlueZ
{
  public delegate Task DeviceChagneEventHandlerAsync(Adapter sender, DeviceFoundEventArgs eventArgs);

  public class Adapter
  {

  }
}
