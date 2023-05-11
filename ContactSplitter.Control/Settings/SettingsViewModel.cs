#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using ContactSplitter.DataStorage;
using ContactSplitter.DataStorage.Contracts;
using ContactSplitter.DataStorage.Contracts.HelperClasses;
using Wpf.Ui.Appearance;

#endregion

namespace ContactSplitter.Control.Settings;

public class SettingsViewModel : INotifyPropertyChanged
{
    private readonly IDataRepository _dataRepository;
    private readonly IProjectSettings _projectSettings;
    private string _newTitleAbbr = string.Empty;
    private string _newTitleFull = string.Empty;
    private string _newPrefix = string.Empty;


    private Brush _textColor = null!;

    public SettingsViewModel(IDataRepository dataRepository, IProjectSettings projectSettings)
    {
        _dataRepository = dataRepository;
        _projectSettings = projectSettings;
        CalculateBrush();

        AddTitleCommand = new DelegateCommand(AddTitle);
        RemoveTitleCommand = new DelegateCommand(RemoveTitle);
        AddPrefixCommand = new DelegateCommand(AddPrefix);
        RemovePrefixCommand = new DelegateCommand(RemovePrefix);
    }

    public ParserType SelectedParser
    {
        get => _projectSettings.Parser;
        set
        {
            _projectSettings.Parser = value;
            OnPropertyChanged();
        }
    }

    public ICommand OpenUrlCommand => new DelegateCommand(url =>
    {
        try
        {
            Process.Start(new ProcessStartInfo(url.ToString() ?? string.Empty) { UseShellExecute = true });
        }
        catch
        {
            // ignored
        }
    });

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
        get => _textColor;
        set
        {
            _textColor = value;
            OnPropertyChanged();
        }
    }

    public List<UiTheme> AvailableThemes { get; } = Enum.GetValues(typeof(UiTheme)).Cast<UiTheme>().ToList();
    public List<ParserType> AvailableParsers { get; } = Enum.GetValues(typeof(ParserType)).Cast<ParserType>().ToList();

    public ObservableCollection<Title> AllTitles
    {
        get => _dataRepository.AllTitles;
        set
        {
            _dataRepository.AllTitles = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<string> AllPrefixes
    {
        get => _dataRepository.AllPrefixes;
        set
        {
            _dataRepository.AllPrefixes = value;
            OnPropertyChanged();
        }
    }

    public string NewTitleFull
    {
        get => _newTitleFull;
        set
        {
            _newTitleFull = value;
            OnPropertyChanged();
        }
    }

    public string NewPrefix
    {
        get => _newPrefix;
        set
        {
            _newPrefix = value;
            OnPropertyChanged();
        }
    }

    public string NewTitleAbbr
    {
        get => _newTitleAbbr;
        set
        {
            _newTitleAbbr = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddTitleCommand { get; set; }
    public ICommand RemoveTitleCommand { get; set; }
    public ICommand AddPrefixCommand { get; set; }
    public ICommand RemovePrefixCommand { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void CalculateBrush()
    {
        TextColour = _projectSettings.Theme == UiTheme.Hell ? Brushes.Black : Brushes.White;
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

    private void RemovePrefix(object prefixObj)
    {
        if (prefixObj is not string prefix) return;
        AllPrefixes.Remove(prefix);
    }

    private void RemoveTitle(object titleObj)
    {
        if (titleObj is not Title title) return;
        AllTitles.Remove(title);
    }

    private void AddPrefix(object x)
    {
        _dataRepository.AllPrefixes.Add(NewPrefix);
        NewPrefix = string.Empty;
    }

    private void AddTitle(object x)
    {
        var title = new Title()
        {
            MaleTitle = NewTitleFull,
            Abbreviation = NewTitleAbbr,
        };

        AllTitles.Add(title);
        NewTitleFull = string.Empty;
        NewTitleAbbr = string.Empty;
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}