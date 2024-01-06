using BTMM.Utility.Save.SaveObject;
using Newtonsoft.Json;

namespace BTMM.Utility.Settings;

public class Settings : JsonSaveObject<Settings>
{
    [JsonProperty] public string? Language { get; private set; }

    public bool SetLanguage(string language)
    {
        if (!Localization.Localization.Instance.InitLanguage(language)) return false;
        Language = language;
        return true;
    }
}
