using System.IO;
using BTMM.Utility.Save;

namespace BTMM.Utility;

public class PathUtility
{
    private const string AssetsPath = "avares://BTMM/assets/";

    public static string AppDataPath => Path.Combine(SaveTools.GetApplicationPath(), "data");

    public static string ApplicationPath => SaveTools.GetApplicationPath();

    public static string UserDataPath => SaveTools.GetUserDataPath();

    public static string SaveDataPath => SaveTools.SaveDataPath;

    public static string GetSaveDataPath(bool isSaveToApplicationFolder) =>
        SaveTools.GetSaveDataPath(isSaveToApplicationFolder);

    public static string GetAssetPath(string assetPath) => AssetsPath + assetPath;
}
