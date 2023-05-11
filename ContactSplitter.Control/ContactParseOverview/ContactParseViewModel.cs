#region

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ContactParser.Contracts;
using ContactSplitter.DataStorage.Contracts;
using ContactSplitter.DataStorage.Contracts.HelperClasses;

#endregion

namespace ContactSplitter.Control.ContactParseOverview;

public class ContactParseViewModel : INotifyPropertyChanged
{
    private readonly IDataRepository _dataRepository;
    private readonly IOfflineContactParser _offlineContactParser;
    private readonly IProjectSettings _projectSettings;
    private readonly IUserGuidingNotes _userGuidingNotes;

    private string _foreName = null!;
    private string _gender = null!;
    private string _input = null!;

    private Visibility _isLoading = Visibility.Collapsed;
    private string _lastName = null!;
    private string _letterSalutation = null!;
    private string _note = null!;
    private string _notParsed = null!;
    private IOnlineContactParser _onlineOnlineContactParser;
    private PossibleContact _parseResult = null!;
    private string _salutation = null!;
    private string _title = null!;

    public ContactParseViewModel(IOnlineContactParser onlineOnlineContactParser,
        IOfflineContactParser offlineContactParser, IDataRepository dataRepository, IUserGuidingNotes userGuidingNotes,
        IProjectSettings projectSettings)
    {
        _onlineOnlineContactParser = onlineOnlineContactParser;
        _offlineContactParser = offlineContactParser;
        _dataRepository = dataRepository;
        _userGuidingNotes = userGuidingNotes;
        _projectSettings = projectSettings;

        ParseCommand = new DelegateCommand(ParseInput);
        SaveCommand = new DelegateCommand(SaveContact);
    }

    public ICommand ParseCommand { get; set; }
    public ICommand SaveCommand { get; set; }

    public string Input
    {
        get => _input;
        set
        {
            if (value == _input) return;
            _input = value;
            OnPropertyChanged();
        }
    }

    public Visibility IsLoading
    {
        get => _isLoading;
        set
        {
            if (value == _isLoading) return;
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public bool Enabled => _projectSettings.Theme == UiTheme.Hell;

    public IOnlineContactParser OnlineContactParser
    {
        get => _onlineOnlineContactParser;
        set
        {
            if (Equals(value, _onlineOnlineContactParser)) return;
            _onlineOnlineContactParser = value;
            OnPropertyChanged();
        }
    }

    public string Salutation
    {
        get => _salutation;
        set
        {
            if (value == _salutation) return;
            _salutation = value;
            OnPropertyChanged();
        }
    }

    public string LetterSalutation
    {
        get => _letterSalutation;
        set
        {
            if (value == _letterSalutation) return;
            _letterSalutation = value;
            OnPropertyChanged();
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            if (value == _title) return;
            _title = value;
            OnPropertyChanged();
        }
    }

    public string Gender
    {
        get => _gender;
        set
        {
            if (value == _gender) return;
            _gender = value;
            OnPropertyChanged();
        }
    }

    public string ForeName
    {
        get => _foreName;
        set
        {
            if (value == _foreName) return;
            _foreName = value;
            OnPropertyChanged();
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (value == _lastName) return;
            _lastName = value;
            OnPropertyChanged();
        }
    }

    public string Note
    {
        get => _note;
        set
        {
            if (value == _note) return;
            _note = value;
            OnPropertyChanged();
        }
    }

    public string NotParsed
    {
        get => _notParsed;
        set
        {
            if (value == _notParsed) return;
            _notParsed = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void SaveContact(object x)
    {
        var contact = new Contact
        {
            FirstName = ForeName,
            LastName = LastName,
            Salutation = Salutation,
            LetterSalutation = LetterSalutation,
            Gender = Gender,
            Title = Title
        };

        if (contact.IsEmpty)
        {
            Note = "Keine Daten angegeben";
            return;
        }

        _dataRepository.AdressBook.Add(contact);

        ClearFields();
    }

    private void ClearFields()
    {
        ForeName = LastName = Salutation = LetterSalutation = Gender = Title = Note = Input = NotParsed = string.Empty;
    }

    private async void ParseInput(object x)
    {
        if (string.IsNullOrEmpty(Input))
        {
            Note = _userGuidingNotes.EmptyInput;
            return;
        }

        IsLoading = Visibility.Visible; /* Loading Symbol */

        var success = false;

        try
        {
            _parseResult = _projectSettings.Parser is ParserType.ChatGpt
                ? await _onlineOnlineContactParser.ParseContact(Input)
                : await _offlineContactParser.ParseContact(Input);
            success = true;
        }
        catch (ApiException)
        {
            Note = "API Error";
        }
        catch (Exception)
        {
            Note = "Interner Fehler";
        }

        IsLoading = Visibility.Collapsed;

        if (!success) return;

        /* Write Parse Results in Fields */
        ForeName = _parseResult.FirstName;
        LastName = _parseResult.LastName;
        Salutation = _parseResult.Salutation;
        LetterSalutation = _parseResult.LetterSalutation;
        Gender = _parseResult.Gender;
        Title = _parseResult.Title;
        Note = _parseResult.Note;
        NotParsed = _parseResult.NotParsed;
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}