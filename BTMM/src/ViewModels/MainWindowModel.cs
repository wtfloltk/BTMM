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

    protected override void AddEvent()
    {
        base.AddEvent();
        _AddWindowSizeEvent();
    }

    #region Window Size

    private void _AddWindowSizeEvent()
    {
        Subscribe(x => x.Width, x => x.Height, _OnResized);
    }

    public void InitWindowSize()
    {
#if DEBUG
        // test default size
        // Settings.Instance.SetWindowSize(Const.DefaultWindowSize.Width, Const.DefaultWindowSize.Height);
#endif
        if (Settings.Instance.WindowSize != null)
        {
            Width = Settings.Instance.WindowSize.Width;
            Height = Settings.Instance.WindowSize.Height;
            Log.Debug("Load Window Setting: Window Size: {0}, {1}", Width, Height);
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
        Log.Verbose("MainWindow Resize: {0}, {1}", width, height);
    }

    public void ResetWindowSize()
    {
        Width = Const.DefaultWindowSize.Width;
        Height = Const.DefaultWindowSize.Height;
    }

    public void SaveWindowSize()
    {
        Settings.Instance.SetWindowSize(Width, Height);
    }

    #endregion
}
