namespace Gb.Oxen.App.ViewModels;

using Gb.Oxen.Core.Interfaces.Docking;
using Prism.Mvvm;

public class DataViewModel : BindableBase, IDockControl
{
    public string Title { get => "Data"; }

    public DockingLocation Position => DockingLocation.ControlPanel;

    public DataViewModel()
    {

    }


}
