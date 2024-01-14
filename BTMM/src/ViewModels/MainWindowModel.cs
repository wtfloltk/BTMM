using System.Collections.Generic;
using BTMM.Common.Defines;
using BTMM.Utility.Logger;
using BTMM.ViewModels.Base;
using ReactiveUI.Fody.Helpers;

namespace BTMM.ViewModels;

public class MainWindowModel : BaseViewModel<MainWindowModel>
{
    [Reactive] public double Width { get; set; } = 916;

    [Reactive] public double Height { get; set; } = 520;

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

    private static void _OnResized(double width, double height)
    {
        Log.Verbose("MainWindow Resize: {0}, {1}", width, height);
    }

    public Size GetWindowSize()
    {
        return new Size(Width, Height);
    }

    public void SetWindowSize(Size size)
    {
        Width = size.Width;
        Height = size.Height;
        Log.Debug("Load Window Setting: Window Size: {0}, {1}", Width, Height);
    }

    #endregion
}
