using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using BTMM.Utility.Logger;
using BTMM.ViewModels;
using BTMM.Views.Base;
using BTMM.Views.Windows;

namespace BTMM.Views;

public partial class MainWindow : BaseWindow<MainWindow, MainWindowModel>
{
    public static MainWindow? Instance { get; private set; }

    public static event Action? OnAppClosingEvent;

    public MainWindow()
    {
        InitializeComponent();
        Instance = this;
        Log.Info("MainWindow Initialize Finish!");
    }

    protected override void AddEvent()
    {
        base.AddEvent();
        Closing += _OnClosing;
    }

    private static void OnAppClosing()
    {
        OnAppClosingEvent?.Invoke();
    }

    // ReSharper disable UnusedParameter.Local
    private void _OnClosing(object? sender, WindowClosingEventArgs e)
    {
        ViewModel?.OnClosing();
        OnAppClosing();
    }

    private void _OnMenu_File_Exit_Click(object? sender, RoutedEventArgs e)
    {
        Close();
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
