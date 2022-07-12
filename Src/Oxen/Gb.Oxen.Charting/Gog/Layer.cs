namespace Gb.Oxen.Charting.Gog;

using Gb.Oxen.Core.Interfaces.Data;
using System.Linq;

public class Layer : ILayer
{
    private IDataSet dataSet;
    private Geom geom;
    private string xVariable;
    private string yVariable;

    public string XVariable { get { return xVariable; } }

    public string YVariable { get { return yVariable; } }

    public Layer(IDataSet dataSet, Geom geom)
    {
        this.dataSet = dataSet;
        this.geom = geom;
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
}