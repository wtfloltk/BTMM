using BTMM.ViewModels.Components;
using BTMM.Views.Base;

namespace BTMM.Views.Components;

public partial class LogPanel : BasePage<LogPanel, LogPanelModel>
{
    public static LogPanel? Instance { get; private set; }

    public LogPanel()
    {
        InitializeComponent();
        Instance = this;
    }
}
