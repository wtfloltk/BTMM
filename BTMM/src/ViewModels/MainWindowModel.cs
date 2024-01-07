using BTMM.Common;
using BTMM.Common.Settings;
using BTMM.Utility.Logger;
using BTMM.ViewModels.Base;
using ReactiveUI.Fody.Helpers;

namespace BTMM.ViewModels;

public class MainWindowModel : BaseViewModel<MainWindowModel>
{
    [Reactive] public double Width { get; set; }

    [Reactive] public double Height { get; set; }

    protected override void Init()
    {
        base.Init();
        _InitWindowSize();
    }

    protected override void AddEvent()
    {
        base.AddEvent();
        Subscribe(x => x.Width, x => x.Height, _OnResized);
    }

    private void _InitWindowSize()
    {
        if (Settings.Instance.WindowSize != null)
        {
            Width = Settings.Instance.WindowSize.Width;
            Height = Settings.Instance.WindowSize.Height;
            Log.Debug("Window Size: {0}, {1}", Width, Height);
        }
        else
        {
            Width = Const.DefaultWindowSize.Width;
            Height = Const.DefaultWindowSize.Height;
            Log.Debug("Window Init Size: {0}, {1}", Width, Height);
        }
    }

    private static void _OnResized(double width, double height)
    {
        Settings.Instance.SetWindowSize(width, height);
    }
}
