using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using BTMM.Utility.Logger;
using BTMM.ViewModels.Components;
using BTMM.Views.Base;
using NP.Ava.UniDockService;

namespace BTMM.Views.Components;

public partial class TopToolBar : BaseComponent<TopToolBar, TopToolBarModel>
{
    // ReSharper disable MemberCanBePrivate.Global
    public static readonly StyledProperty<ObservableCollection<DockItemViewModelBase>?> DockItemsViewModelsProperty =
        AvaloniaProperty.Register<ItemsControl, ObservableCollection<DockItemViewModelBase>?>(
            nameof(DockItemsViewModels));
    // ReSharper restore MemberCanBePrivate.Global

    public ObservableCollection<DockItemViewModelBase>? DockItemsViewModels
    {
        get => GetValue(DockItemsViewModelsProperty);
        set => SetValue(DockItemsViewModelsProperty, value);
    }

    public TopToolBar()
    {
        InitializeComponent();
    }

    #region Click Event

    // ReSharper disable UnusedParameter.Local
    private void _OnToolBarLayoutClick(object? sender, RoutedEventArgs e)
    {
        Log.Info("{0}", DockItemsViewModels);
        Log.Debug("TODO ToolBar Click");
    }

    private void _OnRevertLayoutClick(object? sender, RoutedEventArgs e)
    {
        MainWindow.Instance?.OnRevertLayout();
    }
    // ReSharper restore UnusedParameter.Local

    #endregion
}
