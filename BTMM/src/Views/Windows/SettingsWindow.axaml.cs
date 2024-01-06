using Avalonia.Controls;
using BTMM.ViewModels.Windows;
using BTMM.Views.Base;

namespace BTMM.Views.Windows;

public partial class SettingsWindow : BaseWindow<SettingsWindowModel>
{
    public SettingsWindow()
    {
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        InitializeComponent();
    }
}