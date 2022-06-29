namespace Gb.Oxen.Core.Interfaces.Docking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDockControl
    {
        string Title { get; }

        DockingLocation Position{ get; }
    }
}
