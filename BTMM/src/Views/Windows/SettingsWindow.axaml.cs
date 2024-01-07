using BTMM.ViewModels.Windows;
using BTMM.Views.Base;

namespace BTMM.Views.Windows;

public partial class SettingsWindow : BaseDialog<SettingsWindow, SettingsWindowModel>
{
    public SettingsWindow()
    {
        InitializeComponent();
    }
}
