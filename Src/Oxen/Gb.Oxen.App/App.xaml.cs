namespace Gb.Oxen.App;

using AvalonDock;
using Gb.Oxen.App.Docking;
using Gb.Oxen.App.Ribbon;
using Gb.Oxen.App.Views;
using Gb.Oxen.Core.Interfaces.Services;
using Gb.Oxen.Core.Services;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindowView>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IDataService, DataService>();
    }

    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        regionAdapterMappings.RegisterMapping(typeof(DockingManager), Container.Resolve<DockingRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(Fluent.Ribbon), Container.Resolve<RibbonRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(Fluent.BackstageTabControl), Container.Resolve<BackstageRegionAdapter>());
        base.ConfigureRegionAdapterMappings(regionAdapterMappings);
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
        return new DirectoryModuleCatalog() { ModulePath = @".\" };
    }
}
