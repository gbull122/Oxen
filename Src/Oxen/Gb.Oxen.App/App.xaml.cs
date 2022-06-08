using Gb.Oxen.App.Ribbon;
using Gb.Oxen.App.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Windows;

namespace Gb.Oxen.App
{
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
           
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            regionAdapterMappings.RegisterMapping(typeof(Fluent.Ribbon), Container.Resolve<RibbonRegionAdapter>());

            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        }
    }
}
