using BTMM.Common.Defines;
using BTMM.Utility.Save.SaveObject;
using Newtonsoft.Json;

namespace BTMM.Common.Settings;

public class Settings : JsonSaveObject<Settings>
{
    [JsonProperty] public string? Language { get; private set; }

    [JsonProperty] public Size? WindowSize { get; private set; }

    public bool SetLanguage(string language)
    {
        if (!Localization.Localization.Instance.InitLanguage(language)) return false;
        Language = language;
        Save();
        return true;
    }

    public void SetWindowSize(double w, double h)
    {
        WindowSize ??= new Size();
        WindowSize.Width = w;
        WindowSize.Height = h;
        Save();
    }
}
