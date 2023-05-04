#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Animation;
using ContactParser.Contracts;
using ContactParser.Contracts.Data;
using ContactSplitter.DataStorage;
using ContactSplitter.DataStorage.HelperClasses;

#endregion

namespace ContactSplitter.Control.ContactParseOverview;

public class ContactParseViewModel : INotifyPropertyChanged
{
    private IOnlineContactParser _onlineOnlineContactParser;
    private readonly IOfflineContactParser _offlineContactParser;
    private readonly ProjectSettings _projectSettings;

    private readonly DataRepository _dataRepository;
    private readonly UserGuidingNotes _userGuidingNotes;
    private PossibleContact _parseResult = null!;

    private string _foreName = null!;

    private string _gender = null!;

    private string _input = null!;

    private string _lastName = null!;

    private string _letterSalutation = null!;

    private string _note = null!;

    private string _notParsed = null!;

    private string _salutation = null!;

    private string _title = null!;

    public ContactParseViewModel(IOnlineContactParser onlineOnlineContactParser, IOfflineContactParser offlineContactParser, DataRepository dataRepository, UserGuidingNotes userGuidingNotes, ProjectSettings projectSettings)
    {
        _onlineOnlineContactParser = onlineOnlineContactParser;
        _offlineContactParser = offlineContactParser;
        _dataRepository = dataRepository;
        _userGuidingNotes = userGuidingNotes;
        _projectSettings = projectSettings;

        ParseCommand = new DelegateCommand(ParseInput);
        SaveCommand = new DelegateCommand(SaveContact);
    }

    private void SaveContact(object x)
    {
        var contact = new Contact()
        {
            FirstName = ForeName,
            LastName = LastName,
            Salutation = Salutation,
            LetterSalutation = LetterSalutation,
            Gender = Gender,
            Title = Title,
        };

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

        _parseResult = _projectSettings.Parser is ParserType.ChatGpt ? await _onlineOnlineContactParser.ParseContact(Input) : await _offlineContactParser.ParseContact(Input);

        ForeName = _parseResult.FirstName;
        LastName = _parseResult.LastName;
        Salutation = _parseResult.Salutation;
        LetterSalutation = _parseResult.LetterSalutation;
        Gender = _parseResult.Gender;
        Title = _parseResult.Title;
        Note = _parseResult.Note;
        NotParsed = _parseResult.NotParsed;
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