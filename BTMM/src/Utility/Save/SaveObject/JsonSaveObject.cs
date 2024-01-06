using Newtonsoft.Json;

namespace BTMM.Utility.Save.SaveObject;

public abstract class JsonSaveObject<T> where T : new()
{
    private static readonly string SaveKey = typeof(T).Name;

    private static SaveProxy SaveProxy => SaveTools.Proxy;

    private static T? _instance;

    public static T Instance
    {
        get
        {
            _instance ??= _Load();
            return _instance;
        }
    }

    private static T _Load()
    {
        var data = SaveProxy.GetString(SaveKey);
        if (string.IsNullOrEmpty(data)) return new T();
        var obj = JsonConvert.DeserializeObject<T>(data);
        return obj ?? new T();
    }
    public void Save()
    {
        var value = JsonConvert.SerializeObject(this);
        SaveProxy.SetString(SaveKey, value);
        SaveProxy.Save(SaveKey);
    }

    public string GetSavePath(string key) => SaveProxy.GetSavePath(key);
}