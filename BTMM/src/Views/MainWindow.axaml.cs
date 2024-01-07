using Avalonia.Interactivity;
using BTMM.Utility.Logger;
using BTMM.ViewModels;
using BTMM.Views.Base;
using BTMM.Views.Windows;

namespace BTMM.Views;

public partial class MainWindow : BaseWindow<MainWindow, MainWindowModel>
{
    public static MainWindow? Instance { get; private set; }
    public MainWindow()
    {
        InitializeComponent();
        Instance = this;
        Log.Debug("MainWindow Initialize Finish!");
    }

    // ReSharper disable UnusedParameter.Local
    private void OnMenu_File_Exit_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void OnMenu_Tools_Settings_Click(object? sender, RoutedEventArgs e)
    {
        await SettingsWindow.ShowDialog();
    }

    private async void OnMenu_Help_About_Click(object? sender, RoutedEventArgs e)
    {
        await AboutWindow.ShowDialog();
    }
    // ReSharper restore UnusedParameter.Local
}
