namespace Gb.Oxen.Core.Interfaces.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBaseVariable
{
    IReadOnlyCollection<object> Values { get; }
}