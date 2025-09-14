Lagerverwaltungssoftware – Windows Forms App (.NET 8)

Projektbeschreibung
-------------------
Dieses Projekt ist eine moderne Lagerverwaltungssoftware, die mit C# (.NET 8), Windows Forms und Entity Framework Core entwickelt wurde. Es bietet Funktionen zur Verwaltung von Artikeln, Kategorien, Bestellungen, Warenausgängen, Benutzerrollen und grafischen Statistiken.

Technologien
------------
- .NET 8 (Windows Forms)
- Entity Framework Core
- SQL Server Express LocalDB (Code-First mit .mdf-Datei)
- LiveChartsCore für Diagramme
- Modernes UI mit rollenbasierter Navigation

Features
--------
- Benutzer- und Rollenverwaltung (z. B. Admin, Mitarbeiter)
- Artikelverwaltung mit Kategorie-Filterung und Farbcodierung bei niedrigem Bestand
- Bestellungen und Warenausgänge mit automatischer Bestandsaktualisierung
- Berichte mit Diagrammen (Top 10, Lagerstand etc.)
- Import/Export-Funktionen (CSV, Excel)
- Lagerwarnungen bei Mindestbestand

Systemanforderungen
-------------------
- Windows 10 oder höher
- .NET 8 SDK oder Runtime installiert
- **SQL Server Express LocalDB** installiert  
  (Download: https://www.microsoft.com/de-de/sql-server/sql-server-downloads)

Installation und Ausführung
---------------------------
1. SQL Server Express LocalDB installieren (falls nicht vorhanden)
2. Projekt entpacken
3. Die `.sln`-Datei mit Visual Studio öffnen
4. Projekt kompilieren und starten
5. Datenbank wird automatisch bei erster Ausführung erstellt (`LagerDB.mdf`)
6. Login mit Beispielbenutzer oder über Registrierung möglich

Benutzeranmeldung (Testkonto)
-----------------------------
- Benutzername: `NeginFarahmandnia`
- Passwort: `626176`
- Rolle: `Admin`

Hinweis
-------
Falls keine Datenbankverbindung möglich ist:
- Stelle sicher, dass LocalDB korrekt installiert ist
- Überprüfe im Projekt die Verbindungszeichenfolge im `DbContext`
- Alternativ kann eine vorhandene SQL Server-Instanz verwendet werden

Autor
-----
Erstellt von [Negin Farahmandnia]
Kontakt: [neginfarahmandnia@gmail.com]


Stand: Mai 2025
