# Hyperformer_ContactSplitter
Dieses Dokument soll Aufschluss über Architekturentscheidungen geben.

## Allgemeine Prinzipien

### Composite Components und Dependency Inversion
Die Composite Components Architektur zielt auf eine Entkopplung von Abhängigkeiten auf Projektebene. Eine Komponente besteht immer aus zwei Projekten: Einem Implementierungsprojekt (konkrete Klassen) und einem Contractsprojekt (Interfaces und Datenklassen). Andere Komponenten haben dabei immer nur Abhängigkeiten von einem Contractsprojekt.

Dependency Inversion verfolgt dieses Ziel auf Klassenebene. Konkret soll eine Abhängigkeit nur von Abstraktionen (Interfaces) und nicht von Details (konkreten Klassen) stattfinden.

### Dependency Injection (fehlt aber noch aktuell)
Zur Entkopplung von Abhängigkeiten werden diese in einem zentralen Container erstellt und je nach Notwendigkeit injeziert. 
Bei der Erstellung wird jeder Abstraktion (Interface) eine Konkretisierung (Implementierung) zugeordnet.
Die Injezierung erfolgt über den Konstruktor, in welchem die Abstraktion gefordert wird und die jeweilige Zuordnung geliefert.

All diese Prinzipien sorgen für bessere Austauschbarkeit, Erweiterbarkeit und Modularität. 

## Konkreter Projektaufbau
Projektmappe Hyperformer_ContactSplitter

|__ ContactsParser.Contracts    (siehe Abschnitt "Composite Components")

|__ ContactParser               (eigentliche Logik des Parsens)

|__ ContactSplitter.Control     (UI-Element welches Eingabe und Ausgabe regelt)

|__ ContactSplitter             (Hauptprojekt, die jeweils anderen)

|__ ContactSplitter.Tests       (Testprojekt zur Validierung)

