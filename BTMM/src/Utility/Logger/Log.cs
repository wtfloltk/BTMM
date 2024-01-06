using System;
using Serilog;

namespace BTMM.Utility.Logger;

public static class Log
{
    public enum LogLevel
    {
        Verbose,
        Debug,
        Information,
        Warning,
        Error,
        Fatal
    }

    public const LogLevel Level = LogLevel.Debug;

    private const LogLevel FileLevel = LogLevel.Information;

    private static Serilog.Events.LogEventLevel EventLevel => (Serilog.Events.LogEventLevel)(int)Level;

    private static Serilog.Events.LogEventLevel FileEventLevel => (Serilog.Events.LogEventLevel)(int)FileLevel;

    public static void Initialize()
    {
        Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(EventLevel)
            .WriteTo.Console()
            .WriteTo.Trace()
            .WriteTo.File("log.txt",
            restrictedToMinimumLevel: FileEventLevel,
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();
    }

    public static void Info(string message)
    {
        Serilog.Log.Information(message);
    }

    public static void Info(string message, params object?[]? propertyValues)
    {
        Serilog.Log.Information(message, propertyValues);
    }

    public static void Info<T>(string message, T propertyValue)
    {
        Serilog.Log.Information(message, propertyValue);
    }

    public static void Info<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Information(message, propertyValue0, propertyValue1);
    }

    public static void Info<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Information(message, propertyValue0, propertyValue1, propertyValue2);
    }

    public static void Info<T0, T1, T2, T3>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2, T3 propertyValue3)
    {
        Serilog.Log.Information(message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    public static void Warn(string message)
    {
        Serilog.Log.Warning(message);
    }

    public static void Warn(string message, params object?[]? propertyValues)
    {
        Serilog.Log.Warning(message, propertyValues);
    }

    public static void Warn<T>(string message, T propertyValue)
    {
        Serilog.Log.Warning(message, propertyValue);
    }

    public static void Warn<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Warning(message, propertyValue0, propertyValue1);
    }

    public static void Warn<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Warning(message, propertyValue0, propertyValue1, propertyValue2);
    }

    public static void Warn<T0, T1, T2, T3>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2, T3 propertyValue3)
    {
        Serilog.Log.Warning(message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    public static void Error(string message)
    {
        Serilog.Log.Error(message);
    }

    public static void Error(string message, params object?[]? propertyValues)
    {
        Serilog.Log.Error(message, propertyValues);
    }

    public static void Error<T>(string message, T propertyValue)
    {
        Serilog.Log.Error(message, propertyValue);
    }

    public static void Error<T0, T1>(string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Error(message, propertyValue0, propertyValue1);
    }

    public static void Error<T0, T1, T2>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Error(message, propertyValue0, propertyValue1, propertyValue2);
    }

    public static void Error<T0, T1, T2, T3>(string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2, T3 propertyValue3)
    {
        Serilog.Log.Error(message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    public static void Error(Exception? e,string message)
    {
        Serilog.Log.Error(e, message);
    }

    public static void Error(Exception? e,string message, params object?[]? propertyValues)
    {
        Serilog.Log.Error(e, message, propertyValues);
    }

    public static void Error<T>(Exception? e,string message, T propertyValue)
    {
        Serilog.Log.Error(e, message, propertyValue);
    }

    public static void Error<T0, T1>(Exception? e,string message, T0 propertyValue0, T1 propertyValue1)
    {
        Serilog.Log.Error(e, message, propertyValue0, propertyValue1);
    }

    public static void Error<T0, T1, T2>(Exception? e,string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
    {
        Serilog.Log.Error(e, message, propertyValue0, propertyValue1, propertyValue2);
    }

    public static void Error<T0, T1, T2, T3>(Exception? e,string message, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2, T3 propertyValue3)
    {
        Serilog.Log.Error(e, message, propertyValue0, propertyValue1, propertyValue2, propertyValue3);
    }

    public static void CloseAndFlush()
    {
        Serilog.Log.CloseAndFlush();
    }
}