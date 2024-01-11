using BTMM.ViewModels.Panels;
using BTMM.Views.Base;

namespace BTMM.Views.Panels;

public partial class InspectorPanel : BaseComponent<InspectorPanel, ModListPanelModel>
{
    public static InspectorPanel? Instance { get; private set; }

    public InspectorPanel()
    {
        InitializeComponent();
        Instance = this;
    }
}
