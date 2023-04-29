#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

#endregion

namespace ContactSplitter.Control;

public class MainContainerViewModel : INotifyPropertyChanged
{
    private Visibility _settingsVisibility = Visibility.Collapsed;
    private Visibility _contactListVisibility = Visibility.Collapsed;
    private Visibility _contactParseOverviewVisibility = Visibility.Visible;

    private Brush _einstellungenBackground = Brushes.Transparent;
    private Brush _parserBackground = Brushes.LightBlue;
    private Brush _addressbuchBackground = Brushes.Transparent;

    public MainContainerViewModel()
    {
        ParserCommand = new DelegateCommand(Parser_Click, null);
        AdressbuchCommand = new DelegateCommand(Adressbuch_Click, null);
        EinstellungenCommand = new DelegateCommand(Einstellungen_Click, null);
    }

    public ICommand ParserCommand { get; }
    public ICommand AdressbuchCommand { get; }
    public ICommand EinstellungenCommand { get; }

    public Visibility ContactParseOverviewVisibility
    {
        get => _contactParseOverviewVisibility;
        set
        {
            _contactParseOverviewVisibility = value;
            OnPropertyChanged();
        }
    }

    public Visibility ContactListVisibility
    {
        get => _contactListVisibility;
        set
        {
            _contactListVisibility = value;
            OnPropertyChanged();
        }
    }

    public Visibility SettingsVisibility
    {
        get => _settingsVisibility;
        set
        {
            _settingsVisibility = value;
            OnPropertyChanged();
        }
    }

    public Brush ParserBackground
    {
        get => _parserBackground;
        set
        {
            _parserBackground = value;
            OnPropertyChanged();
        }
    }

    public Brush AdressbuchBackground
    {
        get => _addressbuchBackground;
        set
        {
            _addressbuchBackground = value;
            OnPropertyChanged();
        }
    }

    public Brush EinstellungenBackground
    {
        get => _einstellungenBackground;
        set
        {
            _einstellungenBackground = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private void Parser_Click(object parameter)
    {
        ContactParseOverviewVisibility = Visibility.Visible;
        ContactListVisibility = Visibility.Collapsed;
        SettingsVisibility = Visibility.Collapsed;

        ParserBackground = Brushes.LightBlue;
        AdressbuchBackground = Brushes.Transparent;
        EinstellungenBackground = Brushes.Transparent;
    }

    private void Adressbuch_Click(object parameter)
    {
        ContactParseOverviewVisibility = Visibility.Collapsed;
        ContactListVisibility = Visibility.Visible;
        SettingsVisibility = Visibility.Collapsed;

        ParserBackground = Brushes.Transparent;
        AdressbuchBackground = Brushes.LightBlue;
        EinstellungenBackground = Brushes.Transparent;
    }

    private void Einstellungen_Click(object parameter)
    {
        ContactParseOverviewVisibility = Visibility.Collapsed;
        ContactListVisibility = Visibility.Collapsed;
        SettingsVisibility = Visibility.Visible;

        ParserBackground = Brushes.Transparent;
        AdressbuchBackground = Brushes.Transparent;
        EinstellungenBackground = Brushes.LightBlue;
    }
}