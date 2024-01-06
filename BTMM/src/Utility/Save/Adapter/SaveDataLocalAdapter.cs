using System;
using System.Collections.Generic;
using System.IO;

namespace BTMM.Utility.Save.Adapter;

/// <summary> local folder save data </summary>
public class SaveDataLocalAdapter : ISaveDataAdapter
{
    private static readonly object LockObj = new();

    private const string DefaultFolder = "Data";
    private const string DefaultExName = ".txt";

    public SaveDataLocalAdapter() : this(DefaultFolder, DefaultExName)
    {
    }

    public SaveDataLocalAdapter(string savePath, string exName)
    {
        _exName = exName.ToLower();
        SavePath = Path.IsPathRooted(savePath) ? savePath : Path.Combine(SaveTools.GetApplicationPath(), savePath);
        _Load();
    }

    private readonly string _exName;
    private readonly Dictionary<string, string?> _data = new();

    public string SavePath { get; }

    public void DeleteAll()
    {
        _data.Clear();
        Save();
    }

    public void DeleteKey(string key)
    {
        if (HasKey(key)) _data.Remove(key);
    }

    public string GetString(string key, string defaultValue)
    {
        if (HasKey(key)) return _data[key] ?? defaultValue;
        return defaultValue;
    }

    public void SetString(string key, string value)
    {
        _data[key] = value;
    }

    public bool HasKey(string key)
    {
        return _data.ContainsKey(key);
    }

    public void Save()
    {
        lock (LockObj)
        {
            foreach (var item in _data)
            {
                Save(item.Key);
            }
        }
    }

    public void Save(string key)
    {
        if (!_data.ContainsKey(key)) return;
        var item = _data[key];
        var value = item ?? "";
        var path = GetSavePath(key);
        var folder = Path.GetDirectoryName(path);
        if (folder != null && !Directory.Exists(folder)) Directory.CreateDirectory(folder);
        File.WriteAllText(path, value);
    }

    private void _Load()
    {
        if (!Directory.Exists(SavePath)) return;
        var files = Directory.GetFiles(SavePath);
        if (files.Length == 0) return;
        foreach (var file in files)
        {
            if (!_CheckExName(file)) continue;
            var fileName = Path.GetFileNameWithoutExtension(file);
            if (File.Exists(file))
                _data[fileName] = File.ReadAllText(file);
        }
    }

    private bool _CheckExName(string file)
    {
        var exName = Path.GetExtension(file).ToLower();
        return _exName == exName;
    }

    public string GetSavePath(string key)
    {
        if (key.Contains('\\') || key.Contains('/'))
        {
            throw new Exception("key不支持斜杠");
        }

        return Path.Combine(SavePath, key + _exName);
    }
}
