using System;
using System.IO;
using System.Reflection;
using BTMM.Utility.Save.Adapter;

namespace BTMM.Utility.Save;

public class SaveTools
{
    private static SaveProxy? _proxy;

    public static SaveProxy Proxy => _proxy ??=
        new SaveProxy(new SaveDataLocalAdapter(GetSaveDataPath(IsSaveToApplicationFolder), ".json"));

    public static string SaveDataPath => Proxy.SavePath;

    private static string SaveToApplicationFlagPath => Path.Combine(GetApplicationPath(), "local_setting.txt");

    /// <summary>
    /// Whether to save to the applications folder
    /// </summary>
    public static bool IsSaveToApplicationFolder
    {
        get => File.Exists(SaveToApplicationFlagPath);
        set
        {
            if (value)
            {
                File.WriteAllText(SaveToApplicationFlagPath, "1");
            }
            else if (File.Exists(SaveToApplicationFlagPath))
            {
                File.Delete(SaveToApplicationFlagPath);
            }
        }
    }

    public static string GetSaveDataPath(bool isSaveToApplicationFolder)
    {
        return isSaveToApplicationFolder
            ? Path.Combine(GetApplicationPath(), "userdata")
            : Path.Combine(GetUserDataPath(), "userdata");
    }

    public static string GetApplicationPath()
    {
        var appPath = AppContext.BaseDirectory;
        if (appPath == null)
            throw new Exception("GetApplicationPath Error: appPath is null");

        return appPath;
    }

    public static string GetUserDataPath()
    {
        var assembly = Assembly.GetEntryAssembly();
        var appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var companyName = assembly?.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? "UnknownCompany";
        var productName = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "UnknownProduct";
        return Path.Combine(appPath, companyName, productName);
    }
}
