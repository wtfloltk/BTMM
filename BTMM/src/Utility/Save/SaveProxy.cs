using BTMM.Utility.Save.Adapter;

namespace BTMM.Utility.Save;

public class SaveProxy
{
    private static readonly ISaveDataAdapter DefaultSaveDataAdapter = new SaveDataLocalAdapter();

    private ISaveDataAdapter Adapter { get; }

    public string SavePath => Adapter.SavePath;

    public string GetString(string key, string defaultValue = "")
    {
        return Adapter.GetString(key, defaultValue);
    }

    public void SetString(string key, string value)
    {
        Adapter.SetString(key, value);
    }

    public bool HasKey(string key)
    {
        return Adapter.HasKey(key);
    }

    public void DeleteKey(string key)
    {
        Adapter.DeleteKey(key);
    }

    public void DeleteAll()
    {
        Adapter.DeleteAll();
    }

    public void Save()
    {
        Adapter.Save();
    }

    public void Save(string key)
    {
        Adapter.Save(key);
    }

    public string GetSavePath(string key)
    {
        return Adapter.GetSavePath(key);
    }

    public SaveProxy(ISaveDataAdapter adapter)
    {
        Adapter = adapter;
    }

    public SaveProxy()
    {
        Adapter = DefaultSaveDataAdapter;
    }
}
