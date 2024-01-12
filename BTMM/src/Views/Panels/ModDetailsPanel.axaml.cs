using BTMM.ViewModels.Panels;
using BTMM.Views.Base;

namespace BTMM.Views.Panels;

public partial class ModDetailsPanel : BaseComponent<ModDetailsPanel, ModDetailsPanelModel>
{
    public static ModDetailsPanel? Instance { get; private set; }

    public ModDetailsPanel()
    {
        InitializeComponent();
        Instance = this;
    }
}
