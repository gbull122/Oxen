namespace Gb.Oxen.Charting.Tests;

using Gb.Oxen.Charting.Gog;
using Gb.Oxen.Core.Interfaces.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class LayerTests
{
    [TestMethod]
    public void Test1()
    {
        var dataSet = new Mock<IDataSet>();
        var layer = new Layer(dataSet.Object, Geom.Point);
    }
}