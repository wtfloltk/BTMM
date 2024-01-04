using Avalonia.Controls;
using BTMM.Utility.Localization;

namespace BTMM.Views.Pages;

public partial class SettingsPage : UserControl
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void OnLanguageChanged(object sender, SelectionChangedEventArgs args)
    {
        var cb = sender as ComboBox;
        var language = cb.SelectedIndex == 0 ? "en-US" : "zh-CN";
        Localization.Instance.LoadLanguage(language);
    }
}