using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ContactParser.Contracts;

namespace ContactSplitter.Control;

public class ContactBoxViewModel : INotifyPropertyChanged
{
    private IContactParser _contactParser = null!;
    public ICommand BtnSplit { get; set; }

    private string _input = null!;

    private string Input
    {
        get => _input;
        set
        {
            if (value == _input) return;
            _input = value;
            OnPropertyChanged();
        }
    }

    private string _salutation = null!;

    public string Salutation
    {
        get => _salutation;
        set
        {
            _salutation = value;
            OnPropertyChanged();
        }
    }

    private string _letterSalutation = null!;

    public string LetterSalutation
    {
        get => _letterSalutation;
        set
        {
            _letterSalutation = value;
            OnPropertyChanged();
        }
    }

    private string _title = null!;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    private string _gender = null!;

    public string Gender
    {
        get => _gender;
        set
        {
            _gender = value;
            OnPropertyChanged();
        }
    }

    private string _foreName = null!;

    public string ForeName
    {
        get => _foreName;
        set
        {
            _foreName = value;
            OnPropertyChanged();
        }
    }

    private string _lastName = null!;

    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

    public ContactBoxViewModel()
    {
        BtnSplit = new DelegateCommand((x) =>
        {
            var contact = this._contactParser.ParseContact(this.Input);
            this.ForeName = contact.ForeName;
            this.LastName = contact.LastName;
            this.Gender = contact.Gender;
            this.Title = contact.Title;
            this.LetterSalutation = contact.LetterSalutation;
            this.Salutation = contact.Salutation;
        }, null);
    }

    public IContactParser ContactParser
    {
        get => _contactParser;
        set
        {
            if (Equals(value, _contactParser)) return;
            _contactParser = value;
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
}