using System.Reflection;

namespace BTMM.Common;

public class AppConfig
{
    public static string AppName { get; } =
        Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyProductAttribute>()?.Product ??
        "UnknownProduct";

    public static string CompanyName { get; } =
        Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ??
        "UnknownCompany";

    public static string Version { get; } =
        Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "1.0.0.0";

    public const string Github = "https://github.com/zelda-mods/BTMM";
}
