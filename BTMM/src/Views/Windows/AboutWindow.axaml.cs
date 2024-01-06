using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using BTMM.ViewModels.Windows;
using BTMM.Views.Base;

namespace BTMM.Views.Windows;

public partial class AboutWindow : BaseWindow<AboutWindowModel>
{
    public AboutWindow()
    {
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        InitializeComponent();
    }

    private void OnGithubLinkClick(object? sender, PointerPressedEventArgs _)
    {
        if (sender is TextBlock { Text: not null } text)
        {
            Process.Start(new ProcessStartInfo(text.Text) { UseShellExecute = true });
        }
    }
}
