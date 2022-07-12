namespace Gb.Oxen.Csv.DataProvider;

using Gb.Oxen.Core.Data;
using Gb.Oxen.Core.Interfaces.Data;
using Gb.Oxen.Csv.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class CsvDataProvider:ICsvDataProvider
{

    public async Task<IDataSet> LoadFile(IProgress<string> progress, string path, string datasetName)
    {
        progress.Report("Reading File...");
        var rowWiseRawData = ReadCsvFileRowWise(path);
        var colWiseData = RowWiseToColumnWise(rowWiseRawData);

        progress.Report("Importing Data...");
        var newDataSet = new DataSet(colWiseData, datasetName);

       return newDataSet;
    }

    public IList<string[]> ReadCsvFileRowWise(string filePath)
    {
        List<string[]> rawDataRowWise = new List<string[]>();

        using (var reader = new StreamReader(File.OpenRead(filePath)))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                rawDataRowWise.Add(line.Split(','));
            }
        }

        return rawDataRowWise;
    }

    public List<string[]> RowWiseToColumnWise(IList<string[]> rowWiseData)
    {
        var numberOfColumns = rowWiseData[0].Length;
        var numberOfRows = rowWiseData.Count;
        List<string[]> colWiseData = new List<string[]>(numberOfColumns);


        for (int index = 0; index < numberOfColumns; ++index)
        {
            var col = new List<string>();
            foreach (var row in rowWiseData)
            {
                col.Add(row[index]);
            }

            colWiseData.Add(col.ToArray());
        }

        return colWiseData;
    }
}
