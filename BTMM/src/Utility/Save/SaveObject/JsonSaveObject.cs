using BTMM.Utility.Save.Adapter;

namespace BTMM.Utility.Save.SaveObject;

public abstract class JsonSaveObject<T> where T : new()
{
    private static readonly string saveKey = typeof(T).Name;
    public static SaveProxy SaveProxy { get; protected set; } = new (new SaveDataLocalAdapter("userdata", ".json"));

    private static T? _instance;
    public static T Instance
    {
        get
        {
            _instance ??= Load();
            return _instance;
        }
    }

    protected JsonSaveObject()
    {

    }

    protected static T Load()
    {
        var data = SaveProxy.GetString(saveKey, "");
        if (!string.IsNullOrEmpty(data))
        {
            var obj = JsonUtils.ToObject<T>(data);
            if (obj != null) return obj;
        }
        return new T();
    }
    public void Save()
    {
        var value = JsonUtils.ToJson(this);
        SaveProxy.SetString(saveKey, value);
        SaveProxy.Save(saveKey);
    }
    public string GetSavePath(string key)
    {
        return SaveProxy.GetSavePath(key);
    }
}