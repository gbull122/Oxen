namespace Gb.Oxen.App.ViewModels
{
using Gb.Oxen.Core.Interfaces.Data;
    using Gb.Oxen.Core.Interfaces.Docking;
    using Gb.Oxen.Core.Interfaces.Services;
using Prism.Mvvm;
    using System.Collections.ObjectModel;

    public class DataViewModel:BindableBase,IDockControl
    {
        private readonly IDataService dataService;

        public string Title => "Data";

        public DockingLocation Position => DockingLocation.ControlPanel;

        public ObservableCollection<IDataSet> DataSets
        {
            get { return dataService.DataSets; }
            set
            {
                dataService.DataSets = value;
                RaisePropertyChanged(nameof(DataSets));
            }
        }

        public DataViewModel(IDataService dataService)
        {
            this.dataService = dataService;
        }


    }
}
