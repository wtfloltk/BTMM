using Avalonia.ReactiveUI;
using BTMM.ViewModels.Base;

namespace BTMM.Views.Base;

public class BaseWindow<T> : ReactiveWindow<T> where T : BaseViewModel, new()
{
    protected BaseWindow()
    {
        DataContext = new T();
    }
}