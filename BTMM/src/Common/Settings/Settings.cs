using BTMM.Common.Defines;
using BTMM.Utility.Logger;
using BTMM.Utility.Save.SaveObject;
using Newtonsoft.Json;

namespace BTMM.Common.Settings;

public class Settings : JsonSaveObject<Settings>
{
    [JsonProperty] public string? Language { get; private set; }

    [JsonProperty] public Size? WindowSize { get; private set; }

    [JsonProperty] public string? LogPath { get; private set; }

    public string? SetLanguage(string language)
    {
        var err = Localization.Localization.Instance.InitLanguage(language);
        if (!string.IsNullOrEmpty(err))
        {
            err = $"Change Language Error: {err}";
            Log.Error(err);
            return err;
        }
        Language = language;
        return Save();
    }

    public string? SetWindowSize(double w, double h)
    {
        WindowSize ??= new Size();
        WindowSize.Width = w;
        WindowSize.Height = h;
        return Save();
    }

    public string? SetLogPath(string logPath)
    {
        LogPath = logPath;
        return Save();
    }

    protected override string? Save()
    {
        var err = base.Save();
        if (!string.IsNullOrEmpty(err))
        {
            Log.Error("Save Settings Error: {0}", err);
        }

        return err;
    }
}
