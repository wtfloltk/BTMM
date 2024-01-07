using Avalonia.ReactiveUI;

namespace BTMM.Views.Base;

public abstract class BasePage<TPage, TViewModel> : ReactiveUserControl<TViewModel>
    where TViewModel : class, new()
    where TPage : BasePage<TPage, TViewModel>, new()
{
    protected new TViewModel? ViewModel => base.ViewModel;

    protected BasePage()
    {
        _Init();
    }

    ~BasePage()
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
