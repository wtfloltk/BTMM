using BTMM.ViewModels.Panels;
using BTMM.Views.Base;

namespace BTMM.Views.Panels;

public partial class ModListPanel : BaseComponent<ModListPanel, ModListPanelModel>
{
    public static ModListPanel? Instance { get; private set; }

    public ModListPanel()
    {
        InitializeComponent();
        Instance = this;
    }
}
