using System.Windows.Controls;

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
