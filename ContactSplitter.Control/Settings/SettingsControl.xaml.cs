using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace ContactSplitter.Control.Settings
{
    /// <summary>
    /// Interaktionslogik für SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl(SettingsViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
