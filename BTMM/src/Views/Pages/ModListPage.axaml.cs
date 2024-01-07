using BTMM.ViewModels.Pages;
using BTMM.Views.Base;

namespace BTMM.Views.Pages;

public partial class ModListPage : BasePage<ModListPage, ModListPageModel>
{
    public static ModListPage? Instance { get; private set; }

    public ModListPage()
    {
        InitializeComponent();
        Instance = this;
    }
}
