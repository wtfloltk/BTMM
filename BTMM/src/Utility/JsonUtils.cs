using Newtonsoft.Json;

namespace BTMM.Utility;

public static class JsonUtils
{
    public static string ToJson(object obj, bool isFormat = true)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static T? ToObject<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}
