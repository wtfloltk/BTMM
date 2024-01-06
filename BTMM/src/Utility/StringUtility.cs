using System;

namespace BTMM.Utility;

public class StringUtility
{
    private const long KbSize = 1024;

    private const long MbSize = KbSize * 1024;

    private const long GbSize = MbSize * 1024;

    public static string FormatDateTime(DateTime time)
    {
        return time.ToString("yyyy/MM/dd HH:mm:ss");
    }

    public static string FormatDateTimeFileName(DateTime time)
    {
        return time.ToString("yyyyMMddHHmmss");
    }

    public static string FormatFileSize(long size)
    {
        return size switch
        {
            < KbSize => $"{size} Byte",
            < MbSize => $"{size / KbSize} KB",
            < GbSize => $"{size / MbSize} MB",
            _ => $"{size / GbSize} GB"
        };
    }

    public static bool MatchWildCard(string wildcardPattern, string input, bool greedy = false)
    {
        var regexPattern = wildcardPattern.Replace("?", ".").Replace("*", greedy ? ".*?" : ".*");
        var m = System.Text.RegularExpressions.Regex.Match(input, regexPattern,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        return m.Success;
    }
}
