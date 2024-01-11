using Avalonia.Interactivity;
using BTMM.Utility.Logger;
using BTMM.ViewModels.Components;
using BTMM.Views.Base;

namespace BTMM.Views.Components;

public partial class TopToolBar : BaseComponent<TopToolBar, TopToolBarModel>
{
    public TopToolBar()
    {
        InitializeComponent();
    }

    #region Click Event

    // ReSharper disable UnusedParameter.Local
    private void _OnToolBarLayoutClick(object? sender, RoutedEventArgs e)
    {
        Log.Debug("TODO ToolBar Click");
    }

    private void _OnRevertLayoutClick(object? sender, RoutedEventArgs e)
    {
        MainWindow.Instance?.OnRevertLayout();
    }
    // ReSharper restore UnusedParameter.Local

    #endregion
}
