using BTMM.ViewModels.Pages;
using BTMM.Views.Base;

namespace BTMM.Views.Pages;

public partial class InspectorPage : BasePage<InspectorPage, ModListPageModel>
{
    public static InspectorPage? Instance { get; private set; }

    public InspectorPage()
    {
        InitializeComponent();
        Instance = this;
    }
}
