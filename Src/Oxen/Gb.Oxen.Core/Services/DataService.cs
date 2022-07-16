namespace Gb.Oxen.Core.Services;

using Gb.Oxen.Core.Interfaces.Data;
using Gb.Oxen.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class DataService: IDataService
{
    private ObservableCollection<IDataSet> dataSets;

    public ObservableCollection<IDataSet> DataSets
    {
        get { return dataSets; }
        set
        {
            dataSets = value;
        }
    }

    public DataService()
    {
        dataSets = new ObservableCollection<IDataSet>();
    }

    public bool DataSetAdd(IDataSet dataSet)
    {
        if (dataSets.Contains(dataSet))
            return false;

        DataSets.Add(dataSet);
        return true;
    }

    public IDataSet DataSetGet(string name)
    {
        foreach (var dataSet in dataSets)
        {
            if (dataSet.Name.Equals(name))
                return dataSet;
        }
        return null;
    }

    public IEnumerable<IDataSet> SelectedDataSets()
    {
        var dataSetNames = new List<IDataSet>();

        foreach (var dataSet in DataSets)
        {
            if (dataSet.IsSelected)
                dataSetNames.Add(dataSet);
        }

        return dataSetNames;
    }

    public IList<string> SelectedDataSetsNames()
    {
        var dataSetNames = new List<string>();

        foreach (var dataSet in DataSets)
        {
            if (dataSet.IsSelected)
                dataSetNames.Add(dataSet.Name);
        }

        return dataSetNames;
    }

    public IList<IVariable> SelectedVariables()
    {
        var selection = new List<IVariable>();
        foreach (var dataSet in dataSets)
        {
            foreach (var vari in dataSet.GetVariables())
            {
                if (vari.IsSelected)
                    selection.Add(vari);
            }
        }

        return selection;
    }

    public IEnumerable<string> DataSetNames()
    {
        foreach (var dataSet in dataSets)
        {
            yield return dataSet.Name;
        }
    }

    public IList<string> DataSetVariableNames(string dataSetName)
    {
        foreach (var dataSet in dataSets)
        {
            if (dataSet.Name.Equals(dataSetName))
                return dataSet.VariableNames();
        }
        return null;
    }

    public bool DatasetNameExists(string name)
    {
        foreach (var dataSet in dataSets)
        {
            if (dataSet.Name.Equals(name))
                return true;
        }
        return false;
    }
}
