namespace Gb.Oxen.Charting.Gog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Aesthetic
{
    private string variable;
    private AestheticProperty property;

    public Aesthetic(string variable, AestheticProperty property)
    {
        this.variable = variable;
        this.property = property;
    }
}
