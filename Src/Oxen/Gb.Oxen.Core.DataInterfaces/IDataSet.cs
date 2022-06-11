﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gb.Oxen.Core.Interfaces
{
    public interface IDataSet
    {
        string Name { get; set; }
        List<string> VariableNames();
        List<string> ObservationNames { get; }
        ObservableCollection<IVariable> Variables { get; }
        bool AllColumnsEqual();
        IReadOnlyList<IReadOnlyList<object>> RawData();
        bool IsSelected { get; set; }
    }
}
