namespace Gb.Oxen.Csv.DataProvider
{
    using Gb.Oxen.Csv.Interfaces;
    using Prism.Ioc;
    using Prism.Modularity;
    using System;

    public class CsvDataProviderModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICsvDataProvider, CsvDataProvider>();
        }
    }
}
