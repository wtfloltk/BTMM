using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using BTMM.Utility.Logger;
using ReactiveUI;

namespace BTMM.Utility.Exceptions;

public class ExceptionHandle
{
    public static void Init()
    {
        TaskScheduler.UnobservedTaskException += UnobservedTaskException;
        AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        RxApp.DefaultExceptionHandler = new RxExceptionHandler();
    }

    private static void UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        if (Debugger.IsAttached) Debugger.Break();
        var exception = e.Exception;
        Log.Fatal(exception, exception.Message);
    }

    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (Debugger.IsAttached) Debugger.Break();
        if (e.ExceptionObject is Exception exception)
        {
            Log.Fatal(exception, exception.Message);
        }
        else
        {
            var msg = e.ExceptionObject.ToString();
            if (msg != null)
                Log.Fatal(msg);
        }
    }

    private class RxExceptionHandler : IObserver<Exception>
    {
        public void OnNext(Exception value)
        {
            if (Debugger.IsAttached) Debugger.Break();
            RxApp.MainThreadScheduler.Schedule(() => throw value);
        }

        public void OnError(Exception error)
        {
            if (Debugger.IsAttached) Debugger.Break();
            RxApp.MainThreadScheduler.Schedule(() => throw error);
        }

        public void OnCompleted()
        {
            if (Debugger.IsAttached) Debugger.Break();
            RxApp.MainThreadScheduler.Schedule(() => throw new NotImplementedException());
        }
    }
}
