using Avalonia.ReactiveUI;

namespace BTMM.Views.Base;

public class BaseWindow<TWindow, TViewModel> : ReactiveWindow<TViewModel>
    where TViewModel : class, new()
    where TWindow : BaseWindow<TWindow, TViewModel>, new()
{
    protected new TViewModel? ViewModel => base.ViewModel;

    protected BaseWindow()
    {
        _Init();
    }

    ~BaseWindow()
    {
        _UnInit();
    }

    private void _Init()
    {
        DataContext = new TViewModel();
        Init();
        AddEvent();
    }

    private void _UnInit()
    {
        UnInit();
        RemoveEvent();
    }

    protected virtual void Init()
    {
    }

    protected virtual void UnInit()
    {
    }

    protected virtual void AddEvent()
    {
    }

    protected virtual void RemoveEvent()
    {
    }
}
