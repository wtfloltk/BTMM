using System;
using System.IO;
using BTMM.Utility.Logger;
using BTMM.Utility.Save;

// ReSharper disable MemberCanBePrivate.Global

namespace BTMM.Common;

public class PathConfig
{
    private const string AssetsPath = "avares://BTMM/assets/";

    public static string AppDataPath => Path.Combine(SaveTools.GetApplicationPath(), "data");

    public static string ApplicationPath => SaveTools.GetApplicationPath();

    public static string UserDataPath => SaveTools.GetUserDataPath();

    public static string SaveDataPath => SaveTools.SaveDataPath;

    public static string LogPath => Log.LogPath;

    public static string PresentLayoutPath => GetLayoutPath("present" + AppConfig.LayoutVersion);

    public static string DefaultLayoutPath => GetLayoutPath("default" + AppConfig.LayoutVersion);

    public static string GetSaveDataPath(bool isSaveToApplicationFolder) =>
        SaveTools.GetSaveDataPath(isSaveToApplicationFolder);

    public static string GetAssetPath(string assetPath) => AssetsPath + assetPath;

    private static string GetLayoutFolderPath(string layoutName) => Path.Combine(SaveDataPath, "layouts", layoutName);

    public static string GetLayoutPath(string layoutName) =>
        Path.Combine(GetLayoutFolderPath(layoutName), "layout.xml");
}
