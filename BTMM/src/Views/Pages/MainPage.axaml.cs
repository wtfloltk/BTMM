using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using BTMM.Common.Settings;
using BTMM.ViewModels.Pages;
using BTMM.Views.Base;
using Serilog;

namespace BTMM.Views.Pages;

public partial class MainPage : BasePage<MainPage, MainPageModel>
{
    public static MainPage? Instance { get; private set; }

    public MainPage()
    {
        InitializeComponent();
        Instance = this;
    }

    protected override void Init()
    {
        base.Init();
        _InitLayout();
    }

    protected override void AddEvent()
    {
        base.AddEvent();
        MainWindow.OnAppClosingEvent += OnAppClosing;
    }

    private void OnAppClosing()
    {
        _SaveLayoutData();
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

    private void _OnRevertLayoutClick(object? sender, RoutedEventArgs e)
    {
        _layoutData = _defaultLayoutData?.Copy() ?? new LayoutData();
        _LoadLayoutData(_layoutData);
    }

    private void _OnTestLayoutClick(object? sender, RoutedEventArgs e)
    {
        if (_layoutData != null)
            _LoadLayoutData(_layoutData);
    }

    private void _UpdateToLayoutData(LayoutData layoutData)
    {
        layoutData.ContentHeight = MainGrid.RowDefinitions[0].ActualHeight;
        layoutData.BottomHeight = MainGrid.RowDefinitions[2].ActualHeight;
        layoutData.LeftContentWidth = ContentGrid.ColumnDefinitions[0].ActualWidth;
        layoutData.RightContentWidth = ContentGrid.ColumnDefinitions[2].ActualWidth;
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
}
