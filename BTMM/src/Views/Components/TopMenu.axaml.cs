using Avalonia.Interactivity;
using BTMM.ViewModels.Components;
using BTMM.Views.Base;
using BTMM.Views.Windows;

namespace BTMM.Views.Components;

public partial class TopMenu : BaseComponent<TopMenu, TopMenuModel>
{
    public TopMenu()
    {
        InitializeComponent();
    }

    // ReSharper disable UnusedParameter.Local
    private void _OnMenu_File_Exit_Click(object? sender, RoutedEventArgs e)
    {
        MainWindow.Instance?.Close();
    }

    private async void _OnMenu_Tools_Settings_Click(object? sender, RoutedEventArgs e)
    {
        await SettingsWindow.ShowDialog();
    }

    private async void _OnMenu_Help_About_Click(object? sender, RoutedEventArgs e)
    {
        await AboutWindow.ShowDialog();
    }
    // ReSharper restore UnusedParameter.Local
}
