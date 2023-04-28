using ContactSplitter.Control.ContactEdit;
using ContactSplitter.Control.ContactParseOverview;
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
using ContactSplitter.Control.Settings;

namespace ContactSplitter.Control
{
    /// <summary>
    /// Interaktionslogik für MainContainer.xaml
    /// </summary>
    public partial class MainContainer : UserControl
    {
        public MainContainer()
        {
            InitializeComponent();

            var viewModel = new MainContainerViewModel();

            this.DataContext = viewModel;
        }
    }
}
