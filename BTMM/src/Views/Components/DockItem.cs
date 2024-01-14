using Avalonia;
using Avalonia.Controls;
using NP.Ava.UniDock;

namespace BTMM.Views.Components;

public class DockItem : NP.Ava.UniDock.DockItem
{
    // ReSharper disable MemberCanBePrivate.Global
    public static readonly StyledProperty<string?> IdProperty =
        AvaloniaProperty.Register<ItemsControl, string?>(nameof(Id));
    // ReSharper restore MemberCanBePrivate.Global

    public string? Id
    {
        get => GetValue(IdProperty);
        set => SetValue(IdProperty, value);
    }

    public bool IsDockVisible
    {
        get => GetValue(DockAttachedProperties.IsDockVisibleProperty);
        set => SetValue(DockAttachedProperties.IsDockVisibleProperty, value);
    }
}
