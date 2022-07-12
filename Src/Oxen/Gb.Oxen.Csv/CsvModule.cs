namespace Gb.Oxen.Csv;

using Gb.Oxen.Core;
using Gb.Oxen.Csv.DataProvider;
using Gb.Oxen.Csv.Interfaces;
using Gb.Oxen.Csv.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;



public class CsvModule : IModule
{

    public CsvModule(IRegionManager regionManager)
    {
        regionManager.RegisterViewWithRegion(RegionNames.Ribbon, typeof(RibbonView));
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        
    }
}