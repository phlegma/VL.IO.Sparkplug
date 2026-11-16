# VL.IO.Sparkplug
Sparkplug IOT protool for vvvv

## Group Filter (Änderung gegenüber upstream SparkplugNet)

Upstream abonniert eine `SparkplugApplication` immer den kompletten Namespace `spBv1.0/#`.
Erlaubt der Broker nur eine Gruppe (z. B. `spBv1.0/DEBLO/#`), wird die Subscription abgelehnt
und es kommen keine Daten an.

Deshalb gibt es in `SparkplugApplicationOptions` die optionale Eigenschaft **`GroupFilter`**
(Konstruktor-Parameter `groupFilter`, in VL der Pin **Group Filter** am `SparkplugApplicationOptions.Create`-Node):

| Group Filter      | abonniertes Topic     |
|-------------------|-----------------------|
| leer / nicht gesetzt | `spBv1.0/#` (wie bisher) |
| `DEBLO`           | `spBv1.0/DEBLO/#`     |

Betroffene Dateien (in `src/SparkplugNet/src/SparkplugNet/Core`):
- `Application/SparkplugApplicationOptions.cs`: neue Option `GroupFilter`
- `Application/SparkplugApplicationBase.cs`: `SubscribeInternal()` wertet `GroupFilter` aus
- `Messages/SparkplugTopicGenerator.cs`: neue Methode `GetGroupWildcardSubscribeTopic()`

Hinweise:
- Nach Änderungen an SparkplugNet `VL.IO.Sparkplug` neu bauen (`dotnet build -c Release` in `src/VL.IO.Sparkplug`, Ausgabe in `builds/Release/net8.0`). vvvv muss dafür geschlossen sein, sonst ist die DLL gesperrt.
- Der Pin muss in `VL.IO.Sparkplug.vl` bis nach außen durchgereicht und in der Anwendung (z. B. `3_2_MQTT.vl`) mit der Group Id (`DEBLO`) verbunden werden.
