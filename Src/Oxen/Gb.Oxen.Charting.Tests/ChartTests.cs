namespace Gb.Oxen.Charting.Tests;

using Gb.Oxen.Charting.Gog;
using Gb.Oxen.Core.Interfaces.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class ChartTests
{
    [TestMethod]
    public void TestMethod1()
    {
        var chart = new Chart();

        var data = new Mock<IDataSet>();

        chart.AddLayer(data.Object, Geom.Point);
    }
}