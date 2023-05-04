using ContactSplitter.DataStorage;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactSplitter.Control.UserGuide;

public class UserGuideViewModel : INotifyPropertyChanged
{
    private readonly ProjectSettings _projectSettings;
    private string _bedieneranleitung = "Diese Anwendung ist in verschiedene Seiten aufgeteilt.\r\n\n1. Parser:\r\nEine Eingabestring wird eingegeben, welcher geparste Ergebnisse zurückliefert.\r\nDie Felder können bearbeitet werden und schließlich muss auf Speichern gedrückt werden.\r\n\n2. Adressbuch:\r\nAlle gespeicherten Kontakte sind dort eingetragen. Sie können durch Doppelklick bearbeitet werden.\r\nSortierung wird durch Klick auf die Überschriften erreicht. Filterung durch das Textfeld unten.\r\nEin Button in jeder Zeile ermöglicht das Löschen.\r\n\n3. Anleitung: (hier)\r\n\n4. Einstellungen:\r\nAuf Seite 1 können Titel gelöscht und hinzugefügt werden.\r\nAuf Seite 2 können Präfixe gelöscht und hinzugefügt werden.\r\nAuf Seite 3 kann das Theme und der Parser ausgewählt werden.";

    private string _bestPractices = "Unterschieden wird zwischen zwei Parsern, welche im folgenden weiter erklärt werden.\r\n\r\n1. ChatGPT: \r\nSetzt Internetverbindung vorraus und dauert einige Sekunden.\r\nStellt eine Anfrage an die API von ChatGPT, nutzt also ein Sprachmodell zur Lösung.\r\nVorteil ist, dass diese Version deutlich besser mit Grenzfällen umgehen kann.\r\n\r\n2. Offline:\r\nFunktioniert auch offline und liefert sofort ein Ergebnis.\r\nNutzt einen eigenen Parser, welcher nach fester Logik arbeitet.\r\nNachteil ist, dass die Eingabe in fester Form erfolgen muss und auf Grenzfälle schlechter reagieren kann. \r\nHerr/Frau - Titel (*) - Vornamen (*) - Präfix - Nachname (weitere Nachnamen nur mit -).\r\nEs werden nur Titel und Präfixe erkannt, welche auch in der Datenbank sind.";

    private string _developers = "Mitglieder: Jonathan Schwab, Felix Wochele, Seva Pypenko, Jonas Weis\nTemname: Hyperformer";

    public UserGuideViewModel(ProjectSettings projectSettings)
    {
        _projectSettings = projectSettings;
    }

    public string Bedieneranleitung
    {
        get => _bedieneranleitung;
        set
        {
            _bedieneranleitung = value;
            OnPropertyChanged();
        }
    }

    public string BestPractices
    {
        get => _bestPractices;
        set
        {
            _bestPractices = value;
            OnPropertyChanged();
        }
    }

    public string Developers
    {
        get => _developers;
        set
        {
            _developers = value;
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