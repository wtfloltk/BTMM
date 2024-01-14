using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using BTMM.Common.Defines;
using BTMM.Common.Settings;
using BTMM.Utility.Logger;
using BTMM.ViewModels;
using BTMM.Views.Base;
using NP.Ava.UniDock;

namespace BTMM.Views;

public partial class MainWindow : BaseWindow<MainWindow, MainWindowModel>
{
    public static MainWindow? Instance { get; private set; }

    private DockManager? _dockManager;

    public static event Action? OnAppClosingEvent;

    public MainWindow()
    {
        InitializeComponent();
        Instance = this;
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

    private LayoutData? _defaultLayoutData;

    private void _InitLayout()
    {
        _dockManager = this.FindResource("TheDockManager") as DockManager;
        _defaultLayoutData = _SnapshotLayoutData(true);
        _LoadLayoutData(_defaultLayoutData);
        var layoutData = Settings.Instance.LayoutData;
        _LoadLayoutData(layoutData);
    }

    private void _SaveLayoutData()
    {
        var layoutData = _SnapshotLayoutData();
        Settings.Instance.SetLayoutData(layoutData);
    }

    private void _OnRevertLayout()
    {
        _LoadLayoutData(_defaultLayoutData);
    }

    private LayoutData _SnapshotLayoutData(bool isInitData = false)
    {
        var dockItems = new Dictionary<string, LayoutData.DockItemData>();
        var dockGroups = new Dictionary<string, LayoutData.DockGroupData>();
        try
        {
            if (_dockManager != null)
            {
                foreach (var group in _dockManager.ConnectedGroups)
                {
                    try
                    {
                        if (group is not Components.StackDockGroup dockStackGroup) continue;
                        var key = dockStackGroup.Id;
                        if (string.IsNullOrEmpty(key) || dockGroups.ContainsKey(key)) continue;
                        var size = isInitData ? dockStackGroup.GetInitSize() : dockStackGroup.Size;
                        dockGroups[key] = new LayoutData.DockGroupData
                        {
                            Size = size
                        };
                    }
                    catch (Exception e)
                    {
                        Log.Info("read DockGroup data error: {0}", e.Message);
                    }
                }

                foreach (var item in _dockManager.DockLeafObjs)
                {
                    try
                    {
                        if (item is not Components.DockItem dockItem) continue;
                        var key = dockItem.Id;
                        if (string.IsNullOrEmpty(key) || dockItems.ContainsKey(key)) continue;

                        dockItems[key] = new LayoutData.DockItemData
                        {
                            IsHide = !dockItem.IsDockVisible
                        };
                    }
                    catch (Exception e)
                    {
                        Log.Info("[_SnapshotLayoutData] read DockItem data error: {0}", e.Message);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.Error("[_SnapshotLayoutData] read dockManager data error: {0}", e.Message);
        }

        return new LayoutData
        {
            MainWindowSize = ViewModel?.GetWindowSize() ?? new Size(Width, Height),
            DockItems = dockItems,
            DockGroups = dockGroups
        };
    }

    private void _LoadLayoutData(LayoutData? layoutData)
    {
        if (layoutData == null) return;
        ViewModel?.SetWindowSize(layoutData.MainWindowSize);
        if (_dockManager == null) return;
        try
        {
            if (layoutData.DockGroups != null)
            {
                var groups = _dockManager.ConnectedGroups
                    .OfType<Components.StackDockGroup>().ToList();
                foreach (var (key, value) in layoutData.DockGroups)
                {
                    try
                    {
                        var dockStackGroup = groups.Find(g => g.Id == key);
                        if (dockStackGroup == null) continue;
                        dockStackGroup.Size = value.Size;
                    }
                    catch (Exception e)
                    {
                        Log.Info("[_LoadLayoutData] write DockGroup data error: {0}", e.Message);
                    }
                }
            }

            // ReSharper disable once InvertIf
            if (layoutData.DockItems != null)
            {
                var items = _dockManager.DockLeafObjs.OfType<Components.DockItem>().ToList();
                foreach (var (key, value) in layoutData.DockItems)
                {
                    try
                    {
                        var dockItem = items.Find(i => i.Id == key);
                        if (dockItem == null) continue;
                        dockItem.IsDockVisible = !value.IsHide;
                    }
                    catch (Exception e)
                    {
                        Log.Info("[_LoadLayoutData] write DockItem data error: {0}", e.Message);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.Error("[_LoadLayoutData] write dockManager data error: {0}", e.Message);
        }
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
