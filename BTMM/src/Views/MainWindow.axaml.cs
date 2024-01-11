using System;
using Avalonia.Controls;
using Avalonia.Input;
using BTMM.Common.Settings;
using BTMM.Utility.Logger;
using BTMM.ViewModels;
using BTMM.Views.Base;

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

    protected override void Init()
    {
        base.Init();
        _InitLayout();
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
        _OnRevertLayoutClick();
    }

    #region GridSplitter Change Size

    private LayoutData? _defaultLayoutData;

    private LayoutData? _layoutData;

    private void _InitLayout()
    {
        _defaultLayoutData = new LayoutData();
        _UpdateToLayoutData(_defaultLayoutData);
        if (Settings.Instance.LayoutData != null)
        {
            _layoutData = Settings.Instance.LayoutData;
            _LoadLayoutData(_layoutData);
            Log.Debug(
                "Load Layout Setting: ContentHeight: {0}, BottomHeight: {1}, LeftContentWidth: {2}, RightContentWidth: {3}",
                _layoutData.ContentHeight, _layoutData.BottomHeight, _layoutData.LeftContentWidth,
                _layoutData.RightContentWidth);
        }
        else
        {
            _layoutData = _defaultLayoutData.Copy();
        }
    }

    // ReSharper disable UnusedParameter.Local
    private void _OnRowsPointerMoved(object? sender, PointerEventArgs e)
    {
        if (_layoutData != null)
            _UpdateToLayoutData(_layoutData);
    }

    private void _OnColumnsPointerMoved(object? sender, PointerEventArgs e)
    {
        if (_layoutData != null)
            _UpdateToLayoutData(_layoutData);
    }

    private void _UpdateToLayoutData(LayoutData layoutData)
    {
        layoutData.ContentHeight = MainGrid.RowDefinitions[0].ActualHeight;
        layoutData.BottomHeight = MainGrid.RowDefinitions[2].ActualHeight;
        layoutData.LeftContentWidth = ContentGrid.ColumnDefinitions[0].ActualWidth;
        layoutData.RightContentWidth = ContentGrid.ColumnDefinitions[2].ActualWidth;
    }

    private void _OnRevertLayoutClick()
    {
        _layoutData = _defaultLayoutData?.Copy() ?? new LayoutData();
        _LoadLayoutData(_layoutData);
        ViewModel?.ResetWindowSize();
    }

    private void _SaveLayoutData()
    {
        Settings.Instance.SetLayoutData(_layoutData);
    }

    private void _LoadLayoutData(LayoutData layoutData)
    {
        MainGrid.RowDefinitions[0].Height = _GetGridLength(layoutData.ContentHeight);
        MainGrid.RowDefinitions[2].Height = _GetGridLength(layoutData.BottomHeight);
        ContentGrid.ColumnDefinitions[0].Width = _GetGridLength(layoutData.LeftContentWidth);
        ContentGrid.ColumnDefinitions[2].Width = _GetGridLength(layoutData.RightContentWidth);
    }

    private static GridLength _GetGridLength(double absoluteValue)
    {
        return new GridLength(absoluteValue, GridUnitType.Star);
    }
    // ReSharper restore UnusedParameter.Local

    #endregion

    #region Click Event

    // ReSharper disable UnusedParameter.Local
    private void _OnClosing(object? sender, WindowClosingEventArgs e)
    {
        ViewModel?.OnClosing();
        OnAppClosing();
    }
    // ReSharper restore UnusedParameter.Local

    #endregion
}
