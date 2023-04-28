using ContactSplitter.Control.ContactEdit;
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

namespace ContactSplitter.Control.ContactList
{
    /// <summary>
    /// Interaktionslogik für ContactListControl.xaml
    /// </summary>
    public partial class ContactListControl : UserControl
    {
        public ContactListControl()
        {
            InitializeComponent();

            var viewModel = new ContactListViewModel();

            this.DataContext = viewModel;
        }
    }
}
