using ContactSplitter.DataStorage;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactSplitter.Control.UserGuide;

public class UserGuideViewModel : INotifyPropertyChanged
{
    private readonly ProjectSettings _projectSettings;
    private string _bedieneranleitung = "Diese Anwendung ist in verschiedene Seiten aufgeteilt.\r\n\n1. Parser:\r\nEine Eingabestring wird eingegeben, welcher geparste Ergebnisse zurückliefert.\r\nDie Felder können bearbeitet werden und schließlich muss auf Speichern gedrückt werden.\r\n\n2. Adressbuch:\r\nAlle gespeicherten Kontakte sind dort eingetragen. Sie können durch Doppelklick bearbeitet werden.\r\nSortierung wird durch Klick auf die Überschriften erreicht. Filterung durch das Textfeld unten.\r\nEin Button in jeder Zeile ermöglicht das Löschen.\r\n\n3. Anleitung: (hier)\r\n\n4. Einstellungen:\r\nAuf Seite 1 können Titel gelöscht und hinzugefügt werden.\r\nAuf Seite 2 können Präfixe gelöscht und hinzugefügt werden.\r\nAuf Seite 3 kann das Theme und der Parser ausgewählt werden.";

    private string _bestPractices = "Unterschieden wird zwischen zwei Parsern, welche im folgenden weiter erklärt werden.\r\n\r\n1. ChatGPT: \r\nSetzt Internetverbindung vorraus und dauert einige Sekunden.\r\nStellt eine Anfrage an die API von ChatGPT, nutzt also ein Sprachmodell zur Lösung.\r\nVorteil ist, dass diese Version deutlich besser mit Grenzfällen umgehen kann.\r\nNachteil ist, dass die Ergebnisse bei jedem Aufruf variieren können und auch einfach Fehler enthalten.\r\n\r\n2. Offline:\r\nFunktioniert auch offline und liefert sofort ein Ergebnis.\r\nNutzt einen eigenen Parser, welcher nach fester Logik arbeitet.\r\nNachteil ist, dass die Eingabe in fester Form erfolgen muss und auf Grenzfälle schlechter reagieren kann. \r\nHerr/Frau - Titel (*) - Vornamen (*) - Präfix - Nachname (weitere Nachnamen nur mit -).\r\nEs werden nur Titel und Präfixe erkannt, welche auch in der Datenbank sind.";

    private string _developers = "Mitglieder: Jonathan Schwab, Felix Wochele, Seva Pypenko, Jonas Weis\nTemname: Hyperformer";

    private string _architektur = "Die verwendete Architektur ist eine Composite Components Architektur in Kombination mit einer Schichtenarchitektur. \n\n" +
                                  "Die Composite Componentes Architektur sieht eine Trennung von Schnittstellen und Implementierungen auf Komponentenebene (in .NET also auf Assembly-Ebene) vor. \n" +
                                  "Dies ermöglich eine Austauschbarkeit auf Komponentenebene. Zusätzlich wird das Dependecy Inversion Prinzip eingehalten, welches eine Entkopplung von Schnittstellen " +
                                  "\nauf Implementierungen auf Klassenebene vorsieht. Das Mapping von Schnittstellen und Implementierungen erfolgt über einen Dependecy Injection Container, \n" +
                                  "welcher sich im Hauptprojekt (ContactSplitter) befindet." +
                                  " Das Hauptprojekt konsumiert alle Komponenten und führt entsprechende Kompositionen durch.\n" +
                                  "Diese Schritte ermöglichen eine Testbarkeit, Wiederverwendbarkeit und Austauschbarkeit der Komponenten und Klassen und erhöhen jeweils die Modularität.\n" +
                                  "\nFür das UserInterface-Element des Adressbuches wurde ein getrenntes UserControl erstellt, welches als Bibliothek konsumiert und beliebig eingebunden werden kann.\n" +
                                  "\n\nAus Perspektive der Schichtenarchitektur gibt es die Schichten: Repository, Logik und UI.\n" +
                                  "Bei der UI wird das MVVM Entwurfsmuster verwendet.";

    private string _cleanCode =
        "Zur Einhalung von CleanCode und entsprechender Codierungsrichtlinien, wurde neben Sorgfalt der Entwickler, das Werkzeug Resharper verwendet. \n" +
        "Dieses Werkzeug führt statische Codeanalysen durch und kann mittels syntaktischer semantischer Analyse Antipatterns, Inkonsistenzen, mögliche Vereinfachungen,\n" +
        "sowie verletzungen von Codierungsrichlinien (Namenskonventionen, Einrückung, Formaitierung...) erkennen. Die verwendeten Codierungsrichlinien sind die von der Firma Jetbrains empfohlenen \n" +
        "und im Resharper vorkonfigurierten Richtlinien: https://www.jetbrains.com/dotnet/guide/tutorials/resharper-essentials/";

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

    public string CleanCode
    {
        get => _cleanCode;
        set
        {
            if (value == _cleanCode) return;
            _cleanCode = value;
            OnPropertyChanged();
        }
    }

    public string Architektur
    {
        get => _architektur;
        set
        {
            if (value == _architektur) return;
            _architektur = value;
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
}