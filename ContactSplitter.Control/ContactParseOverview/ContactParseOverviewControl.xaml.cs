using ContactSplitter.Control.ContactList;
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

namespace ContactSplitter.Control.ContactParseOverview
{
    /// <summary>
    /// Interaktionslogik für ContactParseOverviewControl.xaml
    /// </summary>
    public partial class ContactParseOverviewControl : UserControl
    {
        public ContactParseOverviewControl()
        {
            InitializeComponent();

            var viewModel = new ContactParseViewModel();

            this.DataContext = viewModel;
        }
    }
}
