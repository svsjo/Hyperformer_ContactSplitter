using System.Windows.Controls;

namespace ContactSplitter.Control.ContactParseOverview
{
    /// <summary>
    /// Interaktionslogik für ContactParseOverviewControl.xaml
    /// </summary>
    public partial class ContactParseOverviewControl : UserControl
    {
        public ContactParseOverviewControl(ContactParseViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
