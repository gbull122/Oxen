namespace Gb.Oxen.Core.Interfaces.Data;

using System;
using System.Threading.Tasks;

public interface IDataProvider
{
    Task<IDataSet> LoadFile(IProgress<string> progress, string path, string datasetName);
}
