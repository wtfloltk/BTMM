using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;

namespace BTMM.Utility.Localization;

public class LocalizeExtension : MarkupExtension
{
    public LocalizeExtension(string key)
    {
        Key = key;
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public string? Key { get; set; }

    public string? Context { get; set; }

    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties, typeof(Localization))]
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var keyToUse = Key;
        if (!string.IsNullOrWhiteSpace(Context))
            keyToUse = $"{Key}/{Context}";

        var binding = new ReflectionBindingExtension($"[{keyToUse}]")
        {
            Mode = BindingMode.OneWay,
            Source = Localization.Instance,
        };

        return binding.ProvideValue(serviceProvider);
    }
}