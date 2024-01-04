using System.Threading.Tasks;
using Avalonia.Controls;
using BTMM.Views.Pages;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace BTMM.Utility.Dialog;

public class Dialog
{
    public static async Task<ButtonResult> ShowDialog(
        string title,
        string text,
        ButtonEnum @enum = ButtonEnum.Ok,
        Icon icon = Icon.None,
        WindowStartupLocation windowStartupLocation = WindowStartupLocation.CenterOwner)
    {
        var window = MainPage.Instance;
        if (window == null) return ButtonResult.None;
        var dialog = MessageBoxManager.GetMessageBoxStandard(title, text, @enum, icon, windowStartupLocation);
        return await dialog.ShowAsPopupAsync(window);
    }
}