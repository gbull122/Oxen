namespace Gb.Oxen.Charting.StandardProvider;

using Gb.Oxen.Core.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Layer
{
    private IDataSet dataSet;

    public Layer(IDataSet data)
    {
        this.dataSet = data;
    }
}