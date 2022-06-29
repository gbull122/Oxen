using Prism.Commands;
using Prism.Mvvm;

namespace Gb.Oxen.Csv.ViewModels
{
    public class RibbonViewModel : BindableBase
    { 
        public DelegateCommand LoadCsvCommand { get; private set; }
        public DelegateCommand SaveCSVCommand { get; private set; }

        public RibbonViewModel()
        {

        }
    }
}
