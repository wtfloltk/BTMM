using Avalonia.Input;
using BTMM.Common;
using BTMM.ViewModels.Base;

namespace BTMM.ViewModels.Windows;

public class AboutWindowModel : BaseViewModel
{
    public string Version { get; } = AppConfig.Version;

    public string Github { get; } = AppConfig.Github;

    public Cursor LinkCursor { get; } = Const.LinkCursor;
}
