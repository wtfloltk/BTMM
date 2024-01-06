using System.Threading.Tasks;
using Avalonia.Controls;
using BTMM.Utility.Dialog;

namespace BTMM.Views.Pages;

public partial class MainPage : UserControl
{
    public static MainPage? Instance { get; private set; }

    public MainPage()
    {
        InitializeComponent();
        Instance = this;
    }
}