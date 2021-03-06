namespace Gb.Oxen.Core.Data;

using Gb.Oxen.Core.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public class Variable<T> : IVariable, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public int Length { get; }

    public string Name { get; }

    public string Id { get; }
    public IReadOnlyCollection<object> Values { get; }

    public DataFormat Format { get; }
    private bool isSelected;

    public bool IsSelected
    {
        get { return isSelected; }
        set
        {
            isSelected = value;
            RaisePropertyChanged(nameof(IsSelected));
        }
    }

    public Variable(object[] rawData)
    {
        Id = Guid.NewGuid().ToString();

        Name = FormatName(rawData[0].ToString());

        var conversionResult = CanConvertObjectArrayToDoubleArray(rawData);
        if (conversionResult.Item1)
        {
            Values = (IReadOnlyCollection<T>?)conversionResult.Item2;
            Format = DataFormat.Continuous;
        }
        else
        {
        //    DateTime dateResult;
        //    if (DateTime.TryParseExact(rawData[1].ToString(), "dd/MM/yyyy hh:mm:ss",
        //        CultureInfo.InvariantCulture, DateTimeStyles.None, out dateResult))
        //    {
        //        Values = ConvertDoubleToDateTime(rawData);
        //        Format = DataFormat.DateTime;
        //    }
        //    else
        //    {
        //        Values = ArrayToCollection(rawData, true);
        //        Format = DataFormat.Text;
        //    }
        }
        Length = Values.Count;
    }

    public Variable(string name, object[] rawData)
    {
        Id = Guid.NewGuid().ToString();

        Name = name;

        var conversionResult = CanConvertObjectArrayToDoubleArray(rawData, false);
        if (conversionResult.Item1)
        {
            Values = conversionResult.Item2;
            Format = DataFormat.Continuous;
        }
        else
        {
            //DateTime dateResult;
            //if (DateTime.TryParseExact(rawData[1].ToString(), "dd/MM/yyyy hh:mm:ss",
            //    CultureInfo.InvariantCulture, DateTimeStyles.None, out dateResult))
            //{
            //    Values = ConvertDoubleToDateTime(rawData);
            //    Format = DataFormat.DateTime;
            //}
            //else
            //{
            //    Values = ArrayToCollection(rawData, true);
            //    Format = DataFormat.Text;
            //}
        }
        Length = Values.Count;
    }

    public IReadOnlyCollection<object> ArrayToCollection(object[] dataArray, bool trimNans)
    {
        var convertedArray = dataArray.ToList();
        convertedArray.RemoveAt(0);

        if (trimNans)
            return TrimNansFromList(convertedArray);

        return convertedArray;
    }

    public IReadOnlyCollection<object> ConvertDoubleToDateTime(object[] testStringArray)
    {
        var t = testStringArray.ToList();
        t.RemoveAt(0);
        try
        {
            IEnumerable<double> str = t
                            .Select(x => DateTime.ParseExact(x.ToString(), "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture).ToOADate());

            return str.Cast<object>().ToList().AsReadOnly();
        }
        catch
        {
            return null;
        }
    }

    public Tuple<bool, IReadOnlyCollection<T>> CanConvertObjectArrayToDoubleArray(object[] testStringArray, bool removeFirst = true)
    {
        IReadOnlyCollection<double> convertedArray = null;
        var didDataConvert = false;

        var testArray = testStringArray.ToList();

        if (removeFirst)
            testArray.RemoveAt(0);
        try
        {
            IEnumerable<double> str = testArray.Select(x => Convert.ToDouble(x));

            convertedArray = str.Cast<double>().ToList().AsReadOnly();
            didDataConvert = true;

        }
        catch
        {
            ///Do nothing
        }

        return new Tuple<bool, IReadOnlyCollection<T>>(didDataConvert, (IReadOnlyCollection<T>)convertedArray);
    }

    public IReadOnlyCollection<object> TrimNansFromList(List<object> data)
    {
        while (data[data.Count - 1].ToString() == "NaN")
        {
            data.RemoveAt(data.Count - 1);
        }
        return data.AsReadOnly();
    }

    public string FormatName(string name)
    {
        if (Regex.IsMatch(name, @"^\d"))
            name = "V_" + name;

        return name.Replace(' ', '_');
    }
}