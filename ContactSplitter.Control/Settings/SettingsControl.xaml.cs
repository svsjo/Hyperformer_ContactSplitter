using System.Windows.Controls;

namespace ContactSplitter.Control.Settings
{
    /// <summary>
    /// Interaktionslogik für SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            var viewModel = new SettingsViewModel();

            this.DataContext = viewModel;
        }
    }
}
