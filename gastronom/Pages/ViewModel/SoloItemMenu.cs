using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BeautySolutions.View.ViewModel
{
    public class SoloItemMenu
    {
        public SoloItemMenu(string header, PackIconKind icon)
        {
            Header = header;
            Icon = icon;
        }

        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public UserControl Screen { get; private set; }
    }
}