#region

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ContactSplitter.DataStorage;

#endregion

namespace ContactSplitter.Control.Settings;

public class SettingsViewModel : INotifyPropertyChanged
{
    private string _newTitle;

    public SettingsViewModel()
    {
        AddTitleCommand = new DelegateCommand(AddTitle);
        RemoveTitleCommand = new DelegateCommand(RemoveTitle);
    }

    public ObservableCollection<string> AllTitles
    {
        get => DataRepository.AllTitles;
        set
        {
            DataRepository.AllTitles = value;
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