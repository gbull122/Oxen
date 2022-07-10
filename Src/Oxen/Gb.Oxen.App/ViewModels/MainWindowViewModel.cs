namespace Gb.Oxen.App.ViewModels;

using Gb.Oxen.App.Ribbon.Views;
using Gb.Oxen.App.Views;
using Gb.Oxen.Core;
using Prism.Mvvm;
using Prism.Regions;

public class MainWindowViewModel : BindableBase
{
    private IRegionManager regionManager;

    public MainWindowViewModel(IRegionManager regionManager)
    {
        this.regionManager = regionManager;

        regionManager.RegisterViewWithRegion(RegionNames.Ribbon, typeof(MainRibbonView));
        regionManager.RegisterViewWithRegion(RegionNames.Content, typeof(DataView));
    }
}
