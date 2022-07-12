namespace Gb.Oxen.Charting.Gog;

using Gb.Oxen.Core.Interfaces.Data;
using System.Collections.Generic;

public class Chart
{
    private List<ILayer> layers;

    public Chart()
    {
        layers = new List<ILayer>();
    }

    public void AddLayer(IDataSet data, Geom geom)
    {
        var layer = new Layer(data, geom);

        layers.Add(layer);
    }
}
