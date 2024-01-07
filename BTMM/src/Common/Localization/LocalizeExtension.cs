using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;

namespace BTMM.Common.Localization;

public class LocalizeExtension : MarkupExtension
{
    public LocalizeExtension(string key)
    {
        Key = key;
    }

    private string? Key { get; }

    public string? Context { get; set; }

    public string? StringFormat { get; set; }

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
            StringFormat = !string.IsNullOrEmpty(StringFormat) ? StringFormat : null,
        };

        return binding.ProvideValue(serviceProvider);
    }
}
