namespace BTMM.Utility.Save.Adapter;

public interface ISaveDataAdapter
{
    string SavePath { get; }
    string GetSavePath(string key);
    string GetString(string key, string defaultValue);
    void SetString(string key, string value);
    bool HasKey(string key);
    void DeleteKey(string key);
    void DeleteAll();
    void Save();
    void Save(string key);
}
