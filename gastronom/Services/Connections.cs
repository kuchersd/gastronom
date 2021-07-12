using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Threading.Tasks;

namespace gastronom
{
    public class Connections : MainWindow
    {
        public async Task CheckAll()
        {
            await checking_scanner_connection();
            await CheckForInternetConnection();
        }
        public async Task CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    InternetStatus.Kind = PackIconKind.Check;
                }
            }
            catch
            {
                InternetStatus.Kind = PackIconKind.Close;
            }
        }

        public async Task checking_scanner_connection()
        {
            var usbDevices = GetUSBDevices();
            int status = 0;

            foreach (var usbDevice in usbDevices)
            {
                if (usbDevice.PnpDeviceID == @"USB\VID_080C&PID_0300\S/N_C06D07189")  // USB\VID_080C&PID_0300\S/N_C06D07189
                    status = 1;
                // To show all USB-devices.
                //Console.WriteLine("PNP Device ID: {0}, Description: {1}",
                //usbDevice.PnpDeviceID, usbDevice.Description);
            }
            if (status == 1)
            {
                ScannerStatus.Kind = PackIconKind.Check;
            }
            else
            {
                ScannerStatus.Kind = PackIconKind.Close;
            }
        }
        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }

        class USBDeviceInfo
        {
            public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
            {
                this.DeviceID = deviceID;
                this.PnpDeviceID = pnpDeviceID;
                this.Description = description;
            }
            public string DeviceID { get; private set; }
            public string PnpDeviceID { get; private set; }
            public string Description { get; private set; }
        }
    }
    
}
