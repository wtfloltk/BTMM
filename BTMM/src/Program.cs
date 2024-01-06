using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Logging;
using Avalonia.ReactiveUI;
using BTMM.Utility.Exceptions;
using BTMM.Utility.Logger;

namespace BTMM;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            ExceptionHandle.Init();
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }
        catch (Exception e)
        {
            if (Debugger.IsAttached) Debugger.Break();
            Log.Fatal(e, e.Message);
        }
        finally
        {
            Log.CloseAndFlush();
            Log.Info("CloseAndFlush");
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    private static AppBuilder BuildAvaloniaApp()
    {
        Log.Initialize();
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace((LogEventLevel)(int)Log.Level)
            .UseReactiveUI();
    }
}
