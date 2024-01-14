using Newtonsoft.Json;

namespace BTMM.Common.Defines;

public struct Size
{
    [JsonProperty] public double Width { get; set; }
    [JsonProperty] public double Height { get; set; }

    public Size()
    {
    }

    public Size(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override string ToString()
    {
        return $"{Width}, {Height}";
    }
}
