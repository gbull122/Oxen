using System.Collections.Generic;

namespace Gb.Oxen.Core.Interfaces
{
    public interface IVariable
    {
        IReadOnlyCollection<object> Values { get; }
        int Length { get; }
        string Name { get; }
        string Id { get; }
        DataFormat Format { get; }
        bool IsSelected { get; set; }
    }
}
