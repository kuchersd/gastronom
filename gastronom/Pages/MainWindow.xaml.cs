using BeautySolutions.View.ViewModel;
using DropDownMenu;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Management;
using System.Net;
using gastronom.Models;
using System.Linq;

namespace gastronom
{
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();

            //menuOSBB.Add(new SubItem("Create OSBB", new UserControlCustomers()));
            //menuOSBB.Add(new SubItem("Find OSBB", new UserControlProviders()));
            var till = new SoloItemMenu("Каса", PackIconKind.Till);

            var menuSales = new List<SubItem>();
            menuSales.Add(new SubItem("Історія продажів", new UserControlCustomers()));
            menuSales.Add(new SubItem("Find member"));
            menuSales.Add(new SubItem("Delete member"));
            var sales = new ItemMenu("Продажі", menuSales, PackIconKind.Money);

            var menuRecount = new List<SubItem>();
            menuRecount.Add(new SubItem("Почати перерахунок"));
            menuRecount.Add(new SubItem("Історія перерахунків"));
            var recounting = new ItemMenu("Перерахунок", menuRecount, PackIconKind.Calculator);

            var menuProducts = new List<SubItem>();
            menuProducts.Add(new SubItem("Додати товари"));
            menuProducts.Add(new SubItem("Знайти товар"));
            menuProducts.Add(new SubItem("Видалити товар"));
            var products = new ItemMenu("Товари", menuProducts, PackIconKind.Warehouse);

            Menu.Children.Add(new UserControlSoloMenuItem(till, this));
            Menu.Children.Add(new UserControlMenuItem(sales, this));
            Menu.Children.Add(new UserControlMenuItem(recounting, this));
            Menu.Children.Add(new UserControlMenuItem(products, this));
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
    public class Connections
    {
        public void CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    //internet_connection_label.ForeColor = System.Drawing.Color.YellowGreen;
                    //internet_connection_label.Text = "Вкл.";
                }
            }
            catch
            {
                //internet_connection_label.ForeColor = System.Drawing.Color.Firebrick;
                //internet_connection_label.Text = "Выкл.";
            }
        }

        public void checking_scanner_connection()
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
                //scanner_connection_label.ForeColor = System.Drawing.Color.YellowGreen;
                //scanner_connection_label.Text = "Вкл.";
            }
            else
            {
                //internet_connection_label.ForeColor = System.Drawing.Color.Firebrick;
                //scanner_connection_label.Text = "Выкл.";
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
