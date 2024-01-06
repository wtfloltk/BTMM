using Avalonia.Controls;
using BTMM.Utility.Localization;
using BTMM.Utility.Settings;

namespace BTMM.Views.Pages;

public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void OnLanguageChange(object? sender, SelectionChangedEventArgs e)
    {
        var c = sender as ComboBox;
        Settings.Instance.SetLanguage(c.SelectedIndex == 0 ? "en-US" : "zh-CN");
    }
}