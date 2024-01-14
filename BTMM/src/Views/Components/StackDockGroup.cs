using System.Linq;
using Avalonia;
using Avalonia.Controls;
using NP.Ava.Visuals;

namespace BTMM.Views.Components;

public class StackDockGroup : NP.Ava.UniDock.StackDockGroup
{
    // ReSharper disable MemberCanBePrivate.Global
    public static readonly StyledProperty<string?> IdProperty =
        AvaloniaProperty.Register<ItemsControl, string?>(nameof(Id));

    public static readonly StyledProperty<string?> InitSizeProperty =
        AvaloniaProperty.Register<ItemsControl, string?>(nameof(InitSize));
    // ReSharper restore MemberCanBePrivate.Global

    public string? Id
    {
        get => GetValue(IdProperty);
        set => SetValue(IdProperty, value);
    }

    public string? InitSize
    {
        get => GetValue(InitSizeProperty);
        set => SetValue(InitSizeProperty, value);
    }

    public string[] Size
    {
        get => GetSizeCoefficients()
            .Select(item => item.ToCultureInvariantStr())
            .ToArray();
        set => SetSizeCoefficients(value.Select(GridLength.Parse).ToArray());
    }

    public string[] GetInitSize()
    {
        return InitSize != null ? InitSize.Split(" ") : Size;
    }
}
