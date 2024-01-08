using Avalonia.Interactivity;
using Avalonia.ReactiveUI;

namespace BTMM.Views.Base;

public abstract class BasePage<TPage, TViewModel> : ReactiveUserControl<TViewModel>
    where TViewModel : class, new()
    where TPage : BasePage<TPage, TViewModel>, new()
{
    protected new TViewModel? ViewModel => base.ViewModel;

    protected BasePage()
    {
        Loaded += _Loaded;
        Unloaded += _Unloaded;
    }

    private void _Loaded(object? sender, RoutedEventArgs e)
    {
        DataContext = new TViewModel();
        Init();
        AddEvent();
    }

    private void _Unloaded(object? sender, RoutedEventArgs e)
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
