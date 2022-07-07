namespace Gb.Oxen.Core.Interfaces.Services;

using Gb.Oxen.Core.Interfaces.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public interface IDataService
{
    ObservableCollection<IDataSet> DataSets { get; set; }
    IDataSet DataSetGet(string name);
    bool DataSetAdd(IDataSet dataSet);
    IEnumerable<IDataSet> SelectedDataSets();
    IList<IVariable> SelectedVariables();
    IList<string> SelectedDataSetsNames();
    IEnumerable<string> DataSetNames();
    IList<string> DataSetVariableNames(string dataSetName);
    bool DatasetNameExists(string name);
}
