namespace Gb.Oxen.Core.Interfaces.Data;

using System.Collections.Generic;
using System.Collections.ObjectModel;

public interface IDataSet
{
    string Name { get; set; }
    List<string> VariableNames();
    List<string> ObservationNames { get; }
    ObservableCollection<IVariable> GetVariables();
    bool AllColumnsEqual();
    IReadOnlyList<IReadOnlyList<object>> RawData();
    bool IsSelected { get; set; }
}