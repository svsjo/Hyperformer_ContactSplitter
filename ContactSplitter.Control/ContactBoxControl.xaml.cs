using System.Windows.Controls;
using ContactParser;

namespace ContactSplitter.Control
{
    /// <summary>
    /// Interaction logic for ContactBoxControl.xaml
    /// </summary>
    public partial class ContactBoxControl : UserControl
    {
        public ContactBoxControl()
        {
            InitializeComponent();

            var viewModel = new ContactBoxViewModel()
            {
                ContactParser = new DefaultContactParser(),
            };

            this.DataContext = viewModel;
        }
    }
}