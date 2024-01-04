using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BTMM.Utility;

public static class JsonUtils
{
    /// <summary> 转Json字符串 </summary>
    public static string ToJson(object obj, bool isFormat = true)
    {
        var str = JsonConvert.SerializeObject(obj);
        if (isFormat)
        {
            str = FormatJson(str);
        }

        return str;
    }

    /// <summary> 转对象 </summary>
    public static T? ToObject<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    #region Json字符串格式化

    private const string IndentString = "    ";

    private static string FormatJson(string str)
    {
        var indent = 0;
        var quoted = false;
        var sb = new System.Text.StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            var ch = str[i];
            switch (ch)
            {
                case '{':
                case '[':
                    sb.Append(ch);
                    if (!quoted)
                    {
                        sb.AppendLine();
                        ForEach(Enumerable.Range(0, ++indent), _ => sb.Append(IndentString));
                    }

                    break;
                case '}':
                case ']':
                    if (!quoted)
                    {
                        sb.AppendLine();
                        ForEach(Enumerable.Range(0, --indent), _ => sb.Append(IndentString));
                    }

                    sb.Append(ch);
                    break;
                case '"':
                    sb.Append(ch);
                    var escaped = false;
                    var index = i;
                    while (index > 0 && str[--index] == '\\')
                        escaped = !escaped;
                    if (!escaped)
                        quoted = !quoted;
                    break;
                case ',':
                    sb.Append(ch);
                    if (!quoted)
                    {
                        sb.AppendLine();
                        ForEach(Enumerable.Range(0, indent), _ => sb.Append(IndentString));
                    }

                    break;
                case ':':
                    sb.Append(ch);
                    if (!quoted)
                        sb.Append(' ');
                    break;
                default:
                    sb.Append(ch);
                    break;
            }
        }

        return sb.ToString();
    }

    private static void ForEach<T>(IEnumerable<T> ie, Action<T> action)
    {
        foreach (var i in ie) action(i);
    }

    #endregion
}