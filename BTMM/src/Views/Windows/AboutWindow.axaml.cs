using Avalonia.Controls;
using BTMM.ViewModels.Windows;
using BTMM.Views.Base;

namespace BTMM.Views.Windows;

public partial class AboutWindow : BaseWindow<AboutWindowModel>
{
    public AboutWindow()
    {
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        InitializeComponent();
    }
}