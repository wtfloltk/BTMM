using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;

namespace BTMM.Views.Base;

public class BaseDialog<TWindow, TViewModel> : BaseWindow<TWindow, TViewModel>
    where TViewModel : class, new()
    where TWindow : BaseWindow<TWindow, TViewModel>, new()
{
    protected override void Init()
    {
        base.Init();
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
    }

    protected override void AddEvent()
    {
        base.AddEvent();
        KeyUp += OnKeyUp;
    }

    private void OnKeyUp(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Close();
        }
    }

    public static async Task<object?> ShowDialog() => await ShowDialogOwner(MainWindow.Instance);

    private static async Task<object?> ShowDialogOwner(Window? owner)
    {
        var dialog = new TWindow();
        if (owner != null)
        {
            return await dialog.ShowDialog<object?>(owner);
        }

        dialog.Show();
        return null;
    }
}
