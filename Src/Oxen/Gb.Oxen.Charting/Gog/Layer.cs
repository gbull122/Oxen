namespace Gb.Oxen.Charting.Gog;

using Gb.Oxen.Charting.Components;
using Gb.Oxen.Core.Interfaces.Data;
using System.Collections.Generic;
using System.Linq;

public class Layer : ILayer
{
    private IDataSet dataSet;
    private Geom geom;
    private string xVariable;
    private string yVariable;
    private List<Aesthetic> aesthetics;

    public string XVariable { get { return xVariable; } }

    public string YVariable { get { return yVariable; } }

    public Layer(IDataSet dataSet, Geom geom)
    {
        this.dataSet = dataSet;
        this.geom = geom;

        aesthetics = new List<Aesthetic>();
    }

    public void AddAesthetic(string variable, AestheticProperty aestheticProperty)
    {
        if (CanSetVariable(variable))
            aesthetics.Add(new Aesthetic(variable, aestheticProperty));
    }

    public void SetXVariable(string variable)
    {
        if (CanSetVariable(variable))
            xVariable = variable;
    }

    public void SetYVariable(string variable)
    {
        if (CanSetVariable(variable))
            yVariable = variable;
    }

    private bool CanSetVariable(string variable)
    {
        if (dataSet.VariableNames().Contains(variable))
            return true;

        return false;
    }

    public List<Series> Summary()
    {
        var series = new List<Series>();

        series.Add(new Series(geom, xVariable, dataSet., yVariable, ));

        return series;
    }
}