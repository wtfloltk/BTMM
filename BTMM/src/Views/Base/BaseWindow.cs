using Avalonia.Interactivity;
using Avalonia.ReactiveUI;

namespace BTMM.Views.Base;

public class BaseWindow<TWindow, TViewModel> : ReactiveWindow<TViewModel>
    where TViewModel : class, new()
    where TWindow : BaseWindow<TWindow, TViewModel>, new()
{
    protected new TViewModel? ViewModel => base.ViewModel;

    protected BaseWindow()
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
