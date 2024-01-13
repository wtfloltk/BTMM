using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using BTMM.Utility.Logger;
using BTMM.ViewModels.Components;
using BTMM.Views.Base;
using NP.Ava.UniDock;
using NP.Ava.UniDockService;

namespace BTMM.Views.Components;

public partial class TopToolBar : BaseComponent<TopToolBar, TopToolBarModel>
{
    // ReSharper disable MemberCanBePrivate.Global
    public static readonly StyledProperty<DockManager?> TheDockManagerProperty =
        AvaloniaProperty.Register<ItemsControl, DockManager?>(nameof(TheDockManager));
    // ReSharper restore MemberCanBePrivate.Global

    public DockManager? TheDockManager
    {
        get => GetValue(TheDockManagerProperty);
        set => SetValue(TheDockManagerProperty, value);
    }

    public ObservableCollection<DockItemViewModelBase>? DockItemsViewModels =>
        TheDockManager?.DockItemsViewModels ?? null;

    public TopToolBar()
    {
        InitializeComponent();
    }

    #region Click Event

    // ReSharper disable UnusedParameter.Local
    private void _OnToolBarLayoutClick(object? sender, RoutedEventArgs e)
    {
        Log.Info("{0}", TheDockManager);
        Log.Debug("TODO ToolBar Click");
    }

    private void _OnRevertLayoutClick(object? sender, RoutedEventArgs e)
    {
        MainWindow.Instance?.OnRevertLayout();
    }
    // ReSharper restore UnusedParameter.Local

    #endregion
}
