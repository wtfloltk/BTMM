using BTMM.ViewModels.Panels;
using BTMM.Views.Base;

namespace BTMM.Views.Panels;

public partial class LogPanel : BaseComponent<LogPanel, LogPanelModel>
{
    public static LogPanel? Instance { get; private set; }

    public LogPanel()
    {
        InitializeComponent();
        Instance = this;
    }
}
