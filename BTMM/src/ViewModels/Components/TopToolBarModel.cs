using System.Collections.ObjectModel;
using BTMM.ViewModels.Base;
using NP.Ava.UniDockService;

namespace BTMM.ViewModels.Components;

public class TopToolBarModel : BaseViewModel<TopToolBarModel>
{
    public ObservableCollection<DockItemViewModelBase>? DockItemsViewModels { get; set; }
}
