using BTMM.ViewModels.Pages;
using BTMM.Views.Base;

namespace BTMM.Views.Pages;

public partial class MainPage : BasePage<MainPage, MainPageModel>
{
    public static MainPage? Instance { get; private set; }

    public MainPage()
    {
        InitializeComponent();
        Instance = this;
    }
}
