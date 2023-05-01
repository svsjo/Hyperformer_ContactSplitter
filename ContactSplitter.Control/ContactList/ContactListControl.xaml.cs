#region

using System.Windows.Controls;

#endregion

namespace ContactSplitter.Control.ContactList;

/// <summary>
/// Interaktionslogik für ContactListControl.xaml
/// </summary>
public partial class ContactListControl : UserControl
{
    public ContactListControl(ContactListViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}