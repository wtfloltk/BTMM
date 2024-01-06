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
            _instance ??= Load();
            return _instance;
        }
    }

    private JsonSaveObject()
    {
    }

    private static T Load()
    {
        var data = SaveProxy.GetString(SaveKey);
        if (string.IsNullOrEmpty(data)) return new T();
        var obj = JsonUtils.ToObject<T>(data);
        return obj ?? new T();
    }
    public void Save()
    {
        var value = JsonUtils.ToJson(this);
        SaveProxy.SetString(SaveKey, value);
        SaveProxy.Save(SaveKey);
    }

    public string GetSavePath(string key) => SaveProxy.GetSavePath(key);
}