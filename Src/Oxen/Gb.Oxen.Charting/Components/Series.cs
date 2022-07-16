namespace Gb.Oxen.Charting.Components
{
    using Gb.Oxen.Charting.Gog;
    using System.Collections.Generic;

    public class Series
    {
        private string xName;
        private string yName;
        private List<double> xValues;
        private List<double> yValues;
        private Geom geom;

        public Series(Geom geom, string xName, List<double> xValues, string yName, List<double> yValues)
        {
            this.xName = xName;
            this.yName = yName;
            this.xValues = xValues;
            this.yValues = yValues;
            this.geom = geom;
        }
    }
}
