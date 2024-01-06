using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging;
using Avalonia.Markup.Xaml;
using BTMM.Utility.Logger;
using BTMM.ViewModels.Pages;
using BTMM.Views;
using BTMM.Views.Pages;

namespace BTMM;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        Log.Info("1111111111111");
    }

    public override void OnFrameworkInitializationCompleted()
    {
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainPageModel()
                };
                break;
            case ISingleViewApplicationLifetime singleViewPlatform:
                singleViewPlatform.MainView = new MainPage
                {
                    DataContext = new MainPageModel()
                };
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
