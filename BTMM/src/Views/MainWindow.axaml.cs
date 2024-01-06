using Avalonia.Interactivity;
using BTMM.ViewModels;
using BTMM.Views.Base;
using BTMM.Views.Windows;

namespace BTMM.Views;

public partial class MainWindow : BaseWindow<MainWindowModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnMenu_File_Exit_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void OnMenu_Tools_Settings_Click(object? sender, RoutedEventArgs e)
    {
        var settings = new SettingsWindow();
        await settings.ShowDialog(this);
    }

    private async void OnMenu_Help_About_Click(object? sender, RoutedEventArgs e)
    {
        var about = new AboutWindow();
        await about.ShowDialog(this);
    }
}
