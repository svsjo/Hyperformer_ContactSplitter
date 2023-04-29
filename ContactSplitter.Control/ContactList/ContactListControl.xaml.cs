#region

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

#endregion

namespace ContactSplitter.Control.ContactList;

/// <summary>
/// Interaktionslogik für ContactListControl.xaml
/// </summary>
public partial class ContactListControl : UserControl
{
    public ContactListControl()
    {
        InitializeComponent();

        var viewModel = new ContactListViewModel();

        DataContext = viewModel;
    }
}