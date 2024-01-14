using System.Collections.Generic;
using BTMM.Common.Defines;
using Newtonsoft.Json;

namespace BTMM.Common.Settings;

public class LayoutData
{
    [JsonProperty] public Dictionary<string, DockItemData>? DockItems { get; set; }

    [JsonProperty] public Dictionary<string, DockGroupData>? DockGroups { get; set; }
    [JsonProperty] public Size MainWindowSize { get; set; }

    public struct DockItemData
    {
        public bool IsHide;
    }

    public struct DockGroupData
    {
        public string[] Size;
    }
}
