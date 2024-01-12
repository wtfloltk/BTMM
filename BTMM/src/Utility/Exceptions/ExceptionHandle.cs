using System;
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
        var exception = e.Exception;
        Log.Fatal(exception, exception.Message);
    }

    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
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
            RxApp.MainThreadScheduler.Schedule(() => throw value);
        }

        public void OnError(Exception error)
        {
            RxApp.MainThreadScheduler.Schedule(() => throw error);
        }

        public void OnCompleted()
        {
            RxApp.MainThreadScheduler.Schedule(() => throw new NotImplementedException());
        }
    }
}
