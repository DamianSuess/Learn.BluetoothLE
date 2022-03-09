namespace LinuxDbus.Bluetooth.BlueZ;

public static class Constants
{
  public const string DbusService = "org.bluez";

  // Interfaces
  public const string AdapterInterface = "org.bluez.Adapter1";
  public const string DeviceInterface = "org.bluez.Device1";
  public const string GattServiceInterface = "org.bluez.GattService1";
  public const string GattCharacteristicInterface = "org.bluez.GattCharacteristic1";
  public const string MediaInterface = "org.bluez.Media1";

  // Managers
  public const string AgentManager = "org.bluez.AgentManager1";
  public const string GattManager = "org.bluez.GattManager1";
  public const string LeAdvertisingManager = "org.bluez.LEAdvertisingManager1";
  public const string ProfileManager = "org.bluez.ProfileManager1";
  public const string ObjectManager = "org.freedesktop.DBus.ObjectManager";
}
