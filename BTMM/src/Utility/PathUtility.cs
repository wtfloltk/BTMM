using BTMM.Utility.Save;

namespace BTMM.Utility;

public class PathUtility
{
    public static string ApplicationPath => SaveTools.GetApplicationPath();

    public static string UserDataPath => SaveTools.GetUserDataPath();

    public static string SaveDataPath => SaveTools.SaveDataPath;

    public static string GetSaveDataPath(bool isSaveToApplicationFolder) =>
        SaveTools.GetSaveDataPath(isSaveToApplicationFolder);
}