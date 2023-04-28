using System.Windows.Controls;
using ContactParser;
using ContactSplitter.Control.ContactEdit;

namespace ContactSplitter.Control
{
    /// <summary>
    /// Interaction logic for ContactEditControl.xaml
    /// </summary>
    public partial class ContactEditControl : UserControl
    {
        public ContactEditControl()
        {
            InitializeComponent();

            var viewModel = new ContactEditViewModel();

            this.DataContext = viewModel;
        }
    }
}