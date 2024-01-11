using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using HotAvalonia;
using BTMM.Views;

namespace BTMM;

public class App : Application
{
    public override void Initialize()
    {
        this.EnableHotReload();
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindow();
                desktop.ShutdownMode = ShutdownMode.OnMainWindowClose;
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
