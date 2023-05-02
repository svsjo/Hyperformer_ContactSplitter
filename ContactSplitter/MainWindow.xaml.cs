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
using ContactSplitter.Control.ContactParseOverview;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace ContactSplitter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        private readonly CustomControlViewModelMapper _customControlViewModelMapper;

        public MainWindow(MainViewModel viewModel, CustomControlViewModelMapper customControlViewModelMapper)
        {
            _customControlViewModelMapper = customControlViewModelMapper;
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void RootFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            _customControlViewModelMapper.HandleNavigation((ContentControl)e.Content);
        }
    }
}
