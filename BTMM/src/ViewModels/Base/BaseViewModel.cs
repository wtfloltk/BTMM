namespace BTMM.ViewModels.Base;

public abstract class BaseViewModel<TViewModel> : BaseModelObject<TViewModel>
    where TViewModel : BaseViewModel<TViewModel>
{
    protected BaseViewModel()
    {
        _Init();
    }

    ~BaseViewModel()
    {
        _UnInit();
    }

    private void _Init()
    {
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
