using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Input;
using BTMM.ViewModels.Windows;
using BTMM.Views.Base;

namespace BTMM.Views.Windows;

public partial class AboutWindow : BaseDialog<AboutWindow, AboutWindowModel>
{
    public AboutWindow()
    {
        InitializeComponent();
    }

    private void OnGithubLinkClick(object? sender, PointerPressedEventArgs e)
    {
        if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed) return;
        if (sender is TextBlock { Text: not null } text)
        {
            Process.Start(new ProcessStartInfo(text.Text) { UseShellExecute = true });
        }
    }
}
