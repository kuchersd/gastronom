using BeautySolutions.View.ViewModel;

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
/// <summary>
/// Interaction logic for UserControlSoloMenuItem.xaml
/// </summary>
namespace DropDownMenu
{
    public partial class UserControlSoloMenuItem : UserControl
    {
        gastronom.MainWindow _context;
        public UserControlSoloMenuItem(SoloItemMenu itemMenu, gastronom.MainWindow context)
        {
            InitializeComponent();

            _context = context;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
        }
    }
}
