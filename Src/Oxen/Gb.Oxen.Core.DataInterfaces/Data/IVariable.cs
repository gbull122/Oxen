namespace Gb.Oxen.Core.Interfaces.Data;

using System.Collections.Generic;

public interface IVariable
{
    IReadOnlyCollection<object> Values { get; }
    int Length { get; }
    string Name { get; }
    string Id { get; }
    DataFormat Format { get; }
    bool IsSelected { get; set; }
}