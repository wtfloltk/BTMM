using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Avalonia.Platform;
using Newtonsoft.Json;

namespace BTMM.Utility.Localization;

public class Localization : INotifyPropertyChanged
{
    public static Localization Instance { get; private set; } = new("en-US");
    public event PropertyChangedEventHandler? PropertyChanged;

    private const string IndexerName = "Item";
    private const string IndexerArrayName = "Item[]";
    private Dictionary<string, string>? _strings;

    public string Language { get; private set; }

    public string this[string key]
    {
        get
        {
            if (_strings != null && _strings.TryGetValue(key, out var res))
                return System.Text.RegularExpressions.Regex.Unescape(res);
            return $"{Language}:{key}";
        }
    }

    public Localization(string language)
    {
        Language = language;
    }

    public bool LoadLanguage(string language)
    {
        Language = language;
        var uri = new Uri($"avares://BTMM.Core/assets/languages/{language}.json");
        if (!AssetLoader.Exists(uri)) return false;

        using (var sr = new StreamReader(AssetLoader.Open(uri), Encoding.UTF8))
        {
            _strings = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
        }

        OnChange();
        return true;
    }

    private void OnChange()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(IndexerName));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(IndexerArrayName));
    }
}