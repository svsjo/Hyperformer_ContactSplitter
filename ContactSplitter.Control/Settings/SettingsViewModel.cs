#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using ContactSplitter.DataStorage;

#endregion

namespace ContactSplitter.Control.Settings;

public class SettingsViewModel : INotifyPropertyChanged
{
    private string _newTitle = string.Empty;

    private UiTheme _selectedTheme = UiTheme.Dunkel;

    public UiTheme SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            _selectedTheme = value;
            this.ChangeTheme();
            OnPropertyChanged();
        }
    }

    public Color TextColour => SelectedTheme == UiTheme.Hell ? Colors.Black : Colors.White;

    public List<UiTheme> AvailableThemes { get; } = Enum.GetValues(typeof(UiTheme)).Cast<UiTheme>().ToList();
    private readonly DataRepository _dataRepository;

    public SettingsViewModel(DataRepository dataRepository)
    {
        _dataRepository = dataRepository;

        AddTitleCommand = new DelegateCommand(AddTitle);
        RemoveTitleCommand = new DelegateCommand(RemoveTitle);
    }

    public ObservableCollection<string> AllTitles
    {
        get => _dataRepository.AllTitles;
        set
        {
            _dataRepository.AllTitles = value;
            OnPropertyChanged();
        }
    }

    public string NewTitle
    {
        get => _newTitle;
        set
        {
            _newTitle = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddTitleCommand { get; set; }
    public ICommand RemoveTitleCommand { get; set; }

    private void ChangeTheme()
    {
        var wpfTheme = SelectedTheme switch
        {
            UiTheme.Dunkel => Wpf.Ui.Appearance.ThemeType.Dark,
            UiTheme.Hell => Wpf.Ui.Appearance.ThemeType.Light,
            _ => Wpf.Ui.Appearance.ThemeType.Dark,
        };

        Wpf.Ui.Appearance.Theme.Apply(wpfTheme);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void RemoveTitle(object titleObj)
    {
        if (titleObj is not string title) return;
        AllTitles.Remove(title);
    }

    private void AddTitle(object x)
    {
        AllTitles.Add(NewTitle);
        NewTitle = "";
    }

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
}

public enum UiTheme
{
    Dunkel,
    Hell,
}