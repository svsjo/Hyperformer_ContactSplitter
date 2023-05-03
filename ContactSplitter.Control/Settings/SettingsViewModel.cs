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
using Wpf.Ui.Appearance;

#endregion

namespace ContactSplitter.Control.Settings;

public class SettingsViewModel : INotifyPropertyChanged
{
    private readonly DataRepository _dataRepository;
    private readonly ProjectSettings _projectSettings;
    private string _newTitle = string.Empty;

    private Brush _textColour = Brushes.White;

    public SettingsViewModel(DataRepository dataRepository, ProjectSettings projectSettings)
    {
        _dataRepository = dataRepository;
        _projectSettings = projectSettings;

        AddTitleCommand = new DelegateCommand(AddTitle);
        RemoveTitleCommand = new DelegateCommand(RemoveTitle);
    }

    public UiTheme SelectedTheme
    {
        get => _projectSettings.Theme;
        set
        {
            _projectSettings.Theme = value;
            ChangeTheme();
            OnPropertyChanged();
        }
    }

    public Brush TextColour
    {
        get => _textColour;
        set
        {
            _textColour = value;
            OnPropertyChanged();
        }
    }

    public List<UiTheme> AvailableThemes { get; } = Enum.GetValues(typeof(UiTheme)).Cast<UiTheme>().ToList();

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

    public event PropertyChangedEventHandler? PropertyChanged;

    private void CalculateBrush()
    {
        TextColour = SelectedTheme == UiTheme.Hell ? Brushes.Black : Brushes.White;
    }

    private void ChangeTheme()
    {
        var wpfTheme = SelectedTheme switch
        {
            UiTheme.Dunkel => ThemeType.Dark,
            UiTheme.Hell => ThemeType.Light,
            _ => ThemeType.Dark
        };

        Theme.Apply(wpfTheme);

        CalculateBrush();
    }

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