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
        _SaveLayout();
    }

    #region GridSplitter Change Size

    private LayoutData? _defaultLayoutData;

    private LayoutData? _layoutData;

    private void _InitLayout()
    {
        _defaultLayoutData = new LayoutData
        {
            ContentHeight = MainGrid.RowDefinitions[0].ActualHeight,
            BottomHeight = MainGrid.RowDefinitions[2].ActualHeight,
            LeftContentWidth = ContentGrid.ColumnDefinitions[0].ActualWidth,
            RightContentWidth = ContentGrid.ColumnDefinitions[2].ActualWidth
        };
        // if (Settings.Instance.LayoutData != null)
        // {
        //     _layoutData = Settings.Instance.LayoutData;
        //     _UpdateLayoutDataToUI(_layoutData);
        //     Log.Debug(
        //         "Load Layout Setting: ContentHeight: {0}, BottomHeight: {1}, LeftContentWidth: {2}, RightContentWidth: {3}",
        //         _layoutData.ContentHeight, _layoutData.BottomHeight, _layoutData.LeftContentWidth,
        //         _layoutData.RightContentWidth);
        // }
        // else
        // {
        //     _layoutData = _defaultLayoutData.Copy();
        // }
    }

    private void _SaveLayout()
    {
        if (_layoutData != null)
        {
            Settings.Instance.SetLayoutData(_layoutData);
        }
    }

    // ReSharper disable UnusedParameter.Local
    private void _OnRowsPointerMoved(object? sender, PointerEventArgs e)
    {
        if (_layoutData == null) return;
        _layoutData.ContentHeight = MainGrid.RowDefinitions[0].ActualHeight;
        _layoutData.BottomHeight = MainGrid.RowDefinitions[2].ActualHeight;
        Log.Verbose("ContentHeight: {0}, BottomHeight: {1}", _layoutData.ContentHeight, _layoutData.BottomHeight);
    }

    private void _OnColumnsPointerMoved(object? sender, PointerEventArgs e)
    {
        if (_layoutData == null) return;
        _layoutData.LeftContentWidth = ContentGrid.ColumnDefinitions[0].ActualWidth;
        _layoutData.RightContentWidth = ContentGrid.ColumnDefinitions[2].ActualWidth;
        Log.Verbose("LeftContentWidth: {0}, RightContentWidth: {1}", _layoutData.LeftContentWidth,
            _layoutData.RightContentWidth);
    }

    private void _OnRevertLayoutClick(object? sender, RoutedEventArgs e)
    {
        _layoutData = _defaultLayoutData?.Copy() ?? new LayoutData();
        _UpdateLayoutDataToUI(_layoutData);
    }

    private void _UpdateLayoutDataToUI(LayoutData layoutData)
    {
        MainGrid.RowDefinitions[0].Height = _GetGridLength(MainGrid.RowDefinitions[0].Height, layoutData.ContentHeight);
        MainGrid.RowDefinitions[2].Height = _GetGridLength(MainGrid.RowDefinitions[2].Height, layoutData.BottomHeight);
        ContentGrid.ColumnDefinitions[0].Width =
            _GetGridLength(ContentGrid.ColumnDefinitions[0].Width, layoutData.LeftContentWidth);
        ContentGrid.ColumnDefinitions[2].Width =
            _GetGridLength(ContentGrid.ColumnDefinitions[2].Width, layoutData.RightContentWidth);
    }

    private GridLength _GetGridLength(GridLength gridLength, double absoluteValue)
    {
        return gridLength.IsStar
            ? new GridLength(absoluteValue / gridLength.Value, gridLength.GridUnitType)
            : new GridLength(absoluteValue, gridLength.GridUnitType);
    }
    // ReSharper restore UnusedParameter.Local

    #endregion
}
