using Gb.Oxen.App.Ribbon.Views;
using Gb.Oxen.Core;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gb.Oxen.App.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            regionManager.RegisterViewWithRegion(RegionNames.Ribbon, typeof(MainRibbonView));
        }
    }
}
