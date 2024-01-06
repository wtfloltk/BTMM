using Avalonia.ReactiveUI;
using BTMM.ViewModels.Base;

namespace BTMM.Views.Base;

public abstract class BasePage<T> : ReactiveUserControl<T> where T : BaseViewModel, new()
{
    protected BasePage()
    {
        DataContext = new T();
    }
}
