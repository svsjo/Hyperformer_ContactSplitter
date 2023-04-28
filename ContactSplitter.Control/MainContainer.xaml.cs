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
        }

        private void Parser_Click(object sender, RoutedEventArgs e)
        {
            ContactParseOverviewControl.Visibility = Visibility.Visible;
            ContactListControl.Visibility = Visibility.Collapsed;
            SettingsControl.Visibility = Visibility.Collapsed;

            Parser.Background = Brushes.LightBlue;
            Adressbuch.Background = Brushes.Transparent;
            Einstellungen.Background = Brushes.Transparent;
        }

        private void Adressbuch_Click(object sender, RoutedEventArgs e)
        {
            ContactParseOverviewControl.Visibility = Visibility.Collapsed;
            ContactListControl.Visibility = Visibility.Visible;
            SettingsControl.Visibility = Visibility.Collapsed;

            Parser.Background = Brushes.Transparent;
            Adressbuch.Background = Brushes.LightBlue;
            Einstellungen.Background = Brushes.Transparent;
        }

        private void Einstellungen_Click(object sender, RoutedEventArgs e)
        {
            ContactParseOverviewControl.Visibility = Visibility.Collapsed;
            ContactListControl.Visibility = Visibility.Collapsed;
            SettingsControl.Visibility = Visibility.Visible;

            Parser.Background = Brushes.Transparent;
            Adressbuch.Background = Brushes.Transparent;
            Einstellungen.Background = Brushes.LightBlue;
        }
    }
}
