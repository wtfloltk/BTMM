using System;

namespace BTMM.Utility;

public class PathUtility
{
    public static string GetApplicationPath()
    {
        var appPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        if (appPath == null)
        {
            throw new Exception("GetApplicationPath Error: appPath is null");
        }

        return appPath;
    }
}