using System;
using System.IO;
using System.Linq;
using System.Text;
using Avalonia.Controls;
using BTMM.Common;
using BTMM.Utility;
using BTMM.Utility.Logger;
using BTMM.ViewModels;
using BTMM.Views.Base;
using NP.Ava.UniDock;

namespace BTMM.Views;

public partial class MainWindow : BaseWindow<MainWindow, MainWindowModel>
{
    public static MainWindow? Instance { get; private set; }

    private readonly DockManager _dockManager;

    public static event Action? OnAppClosingEvent;

    public MainWindow()
    {
        InitializeComponent();
        Instance = this;
        _dockManager = (DockManager)this.FindResource("TheDockManager")!;
        _InitLayout();
        Log.Debug("MainWindow Initialize Finish!");
    }

    protected override void AddEvent()
    {
        base.AddEvent();
        Closing += _OnClosing;
    }

    private void OnAppClosing()
    {
        _SaveLayoutData();
        OnAppClosingEvent?.Invoke();
    }

    public void OnRevertLayout()
    {
        _OnRevertLayout();
    }

    #region Layout

    private void _InitLayout()
    {
        _InitDockLayout();
        _LoadDockLayout(PathConfig.PresentLayoutPath);
        ViewModel?.InitWindowSize();
    }

    private void _SaveLayoutData()
    {
        _SaveDockLayout(PathConfig.PresentLayoutPath);
        ViewModel?.SaveWindowSize();
    }

    private void _OnRevertLayout()
    {
        _RevertDockLayout();
        ViewModel?.ResetWindowSize();
    }

    #endregion

    #region Dock Layout

    private void _InitDockLayout()
    {
        _SaveDockLayout(PathConfig.DefaultLayoutPath);
    }

    private void _RevertDockLayout()
    {
        _LoadDockLayout(PathConfig.DefaultLayoutPath);
    }

    private void _LoadDockLayout(string layoutPath)
    {
        if (!Fs.ExistFile(layoutPath)) return;
        _dockManager.RestoreFromFile(layoutPath);
    }

    private void _SaveDockLayout(string layoutPath)
    {
        Fs.CheckFileSavePath(layoutPath);
        _dockManager.SaveToFile(layoutPath);
    }

    #endregion

    #region Click Event

    // ReSharper disable UnusedParameter.Local
    private void _OnClosing(object? sender, WindowClosingEventArgs e)
    {
        Log.Debug("MainWindow OnClosing");
        OnAppClosing();
    }
    // ReSharper restore UnusedParameter.Local

    #endregion
}
