using BeautySolutions.View.ViewModel;
using DropDownMenu;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using gastronom.Models;
using System.Linq;
using gastronom.Services;
using System;
using System.Threading.Tasks;

namespace gastronom
{
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();

            var menuTill = new List<SubItem>();
            menuTill.Add(new SubItem("Інтерфейс", new UserControlCustomers()));
            var till = new ItemMenu("Каса", menuTill, PackIconKind.Money);

            var menuSales = new List<SubItem>();
            menuSales.Add(new SubItem("Історія продажів", new UserControlProviders()));
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

            
            Menu.Children.Add(new UserControlMenuItem(till, this));
            Menu.Children.Add(new UserControlMenuItem(sales, this));
            Menu.Children.Add(new UserControlMenuItem(recounting, this));
            Menu.Children.Add(new UserControlMenuItem(products, this));


            Button updateButton = new Button();
            updateButton.Content = "Встановити оновлення";
            updateButton.Name = "updateButton";

            Menu.Children.Add(updateButton);

            updateButton.Visibility = Visibility.Hidden;


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

        public async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            await UserLogin();
            
        }

        public async Task UserLogin()
        {
            IDataService<Account> accountService = new GenericDataService<Account>(new DbContextFactory());

            var allEntities = await accountService.GetAll();

            foreach (var allent in allEntities)
            {
                if (Convert.ToInt32(txtPassword.Password) == allent.PinCode)
                {
                    lbl_UserName.Content = allent.UserName;
                    Menu.IsEnabled = true;
                }
                    
                else
                    lblWrongPinCode.Visibility = Visibility.Visible;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            await GetConnections();
        }
        public async Task GetConnections()
        {
            Connections connections = new Connections();
            await connections.CheckAll();
        }
    }
    
}
