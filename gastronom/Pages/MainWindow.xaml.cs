using BeautySolutions.View.ViewModel;
using DropDownMenu;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gastronom
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //menuOSBB.Add(new SubItem("Create OSBB", new UserControlCustomers()));
            //menuOSBB.Add(new SubItem("Find OSBB", new UserControlProviders()));
            //menuOSBB.Add(new SubItem("Delete OSBB"));
            var item6 = new SoloItemMenu("Каса", PackIconKind.Till);

            var menuMembers = new List<SubItem>();
            menuMembers.Add(new SubItem("Історія продажів"));
            menuMembers.Add(new SubItem("Find member"));
            menuMembers.Add(new SubItem("Delete member"));
            var item1 = new ItemMenu("Продажі", menuMembers, PackIconKind.Money);

            var menuApartments = new List<SubItem>();
            menuApartments.Add(new SubItem("Почати перерахунок"));
            menuApartments.Add(new SubItem("Історія перерахунків"));
            var item2 = new ItemMenu("Перерахунок", menuApartments, PackIconKind.Calculator);

            var menuServices = new List<SubItem>();
            menuServices.Add(new SubItem("Додати товари"));
            menuServices.Add(new SubItem("Знайти товар"));
            menuServices.Add(new SubItem("Видалити товар"));
            var item3 = new ItemMenu("Товари", menuServices, PackIconKind.Warehouse);

            Menu.Children.Add(new UserControlSoloMenuItem(item6, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
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
    }
    
}
