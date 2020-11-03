# Yoga

Dieses Repo enthält den Fork von Yoga mit leichten Anpassungen (Runden: `YogaRounding.NoSpecialTreatment`).
Alle Anpassungen befinden sich auf dem Branch [`RecomFork`](https://github.com/RECOMGmbH/Yoga/tree/RecomFork).
Aufgrund des Forkens enthält das Repo aber viel mehr, als für GRIPS benötigt wird.

## Erstellen

Die VS-Solutions werden im Head-Repo schlecht bis überhaupt nicht gepflegt. In diesem Fork existieren die Solutions, welche mit zuletzt mit VS2019 übersetzen:
 * `csharp/Windows/Facebook.Yoga.sln`

    Enthält für uns benötigten Projekte mit dem NetFramework als Target.
    Enthält alle Basisprojekte (Abhängigkeiten).
    Enthält aber zusätzlich Projekte für UWP.

 * `csharp/Windows/Facebook.Yoga.Desktop.sln`

    Enthält für uns benötigten Projekte mit dem NetFramework als Target.
    Enthält alle Basisprojekte (Abhängigkeiten).

## NuGet

Zum Erstellen des NuGet-Pakets existiert in diesem Fork ein PowerShell Skript:
 * `csharp/nuget/CreatePackage.ps1`

Dieses Skript übersetzt die o.g. Projekte mit MSBuild (von VS2019 - der Pfad ggf. anzupassen) und packt die Resultate mittels NuGet.
Vor dem Erzeugen sollte die Version in der nuspec-Datei (`csharp/nuget/Facebook.Yoga.nuspec`) erhöht werden, wenn beabsichtigt wird, einen aktuelleren Stand zu verteilen.

Das Ergebnis-Paket kann auf den NuGet-Server übertragen werden. (http://hazelhen.local.recom.lan:8624/packages)

## Update vom Head-Repo

Änderungen vom Ursprungs-Repo können folgendermaßen übertragen werden:

1. master-Branch im Fork auf den Stand des Head-Repo bringen

   * Einen zweiten Remote (`https://github.com/facebook/yoga.git`) im geklonten Repo anlegen.
   * Merge von facebook/yoga:master -> recom/yoga:master durchführen (da auf dem master keine Änderungen erfolgt sind, sollte dies ein trivialer Merge sein)

2. master-Branch in den Branch `RecomFork` mergen und ggf. Konflikte auflösen (auch im nativen Cpp-Teil von Yoga gibt es Anpassungen)
