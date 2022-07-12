namespace Gb.Oxen.Csv.Interfaces;

using Gb.Oxen.Core.Interfaces.Data;
using System;
using System.Threading.Tasks;

public interface ICsvDataProvider
{
    Task<IDataSet> LoadFile(IProgress<string> progress, string path, string datasetName);
}
