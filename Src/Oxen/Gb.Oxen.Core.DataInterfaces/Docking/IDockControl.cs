namespace Gb.Oxen.Core.Interfaces.Docking;

public interface IDockControl
{
    string Title { get; }

    DockingLocation Position { get; }
}