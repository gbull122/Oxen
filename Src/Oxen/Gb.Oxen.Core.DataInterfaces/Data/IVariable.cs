namespace Gb.Oxen.Core.Interfaces.Data;

using System.Collections.Generic;

public interface IVariable
{
    IReadOnlyCollection<object> Values { get; }
    DataFormat Format { get; }
    bool IsSelected { get; set; }
    int Length { get; }
    string Name { get; }
    string Id { get; }
}