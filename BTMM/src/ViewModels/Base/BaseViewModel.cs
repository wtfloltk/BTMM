using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ReactiveUI;

namespace BTMM.ViewModels.Base;

public abstract class BaseViewModel<TViewModel> : ReactiveObject where TViewModel : BaseViewModel<TViewModel>
{
    private readonly List<IDisposable?> _subscribes = new();

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
        _Dispose();
    }

    private void _Dispose()
    {
        foreach (var subscribe in _subscribes)
        {
            try
            {
                subscribe?.Dispose();
            }
            catch
            {
                // ignored
            }
        }
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

    #region Subscribe

    protected void Subscribe<TRet>(
        Expression<Func<TViewModel, TRet>> property1,
        Action<TRet> subscribe)
    {
        var disposable = (this as TViewModel).WhenAnyValue(property1)
            .Subscribe(subscribe);
        _subscribes.Add(disposable);
    }

    protected void Subscribe<T1, T2>(
        Expression<Func<TViewModel, T1>> property1,
        Expression<Func<TViewModel, T2>> property2,
        Action<T1, T2> subscribe)
    {
        var disposable = (this as TViewModel).WhenAnyValue(property1, property2)
            .Subscribe(tuple => subscribe(tuple.Item1, tuple.Item2));
        _subscribes.Add(disposable);
    }

    protected void Subscribe<T1, T2, T3>(
        Expression<Func<TViewModel, T1>> property1,
        Expression<Func<TViewModel, T2>> property2,
        Expression<Func<TViewModel, T3>> property3,
        Action<T1, T2, T3> subscribe)
    {
        var disposable = (this as TViewModel).WhenAnyValue(property1, property2, property3)
            .Subscribe(tuple => subscribe(tuple.Item1, tuple.Item2, tuple.Item3));
        _subscribes.Add(disposable);
    }

    protected void Subscribe<T1, T2, T3, T4>(
        Expression<Func<TViewModel, T1>> property1,
        Expression<Func<TViewModel, T2>> property2,
        Expression<Func<TViewModel, T3>> property3,
        Expression<Func<TViewModel, T4>> property4,
        Action<T1, T2, T3, T4> subscribe)
    {
        var disposable = (this as TViewModel).WhenAnyValue(property1, property2, property3, property4)
            .Subscribe(tuple => subscribe(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));
        _subscribes.Add(disposable);
    }

    protected void Subscribe<T1, T2, T3, T4, T5>(
        Expression<Func<TViewModel, T1>> property1,
        Expression<Func<TViewModel, T2>> property2,
        Expression<Func<TViewModel, T3>> property3,
        Expression<Func<TViewModel, T4>> property4,
        Expression<Func<TViewModel, T5>> property5,
        Action<T1, T2, T3, T4, T5> subscribe)
    {
        var disposable = (this as TViewModel).WhenAnyValue(property1, property2, property3, property4, property5)
            .Subscribe(tuple => subscribe(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5));
        _subscribes.Add(disposable);
    }

    protected void Subscribe<T1, T2, T3, T4, T5, T6>(
        Expression<Func<TViewModel, T1>> property1,
        Expression<Func<TViewModel, T2>> property2,
        Expression<Func<TViewModel, T3>> property3,
        Expression<Func<TViewModel, T4>> property4,
        Expression<Func<TViewModel, T5>> property5,
        Expression<Func<TViewModel, T6>> property6,
        Action<T1, T2, T3, T4, T5, T6> subscribe)
    {
        var disposable = (this as TViewModel)
            .WhenAnyValue(property1, property2, property3, property4, property5, property6)
            .Subscribe(tuple =>
                subscribe(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6));
        _subscribes.Add(disposable);
    }

    #endregion
}
