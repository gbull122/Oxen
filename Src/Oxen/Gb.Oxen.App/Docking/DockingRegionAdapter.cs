namespace Gb.Oxen.App.Docking;

using AvalonDock;
using Prism.Regions;

public class DockingRegionAdapter : RegionAdapterBase<DockingManager>
{
    public DockingRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
       : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, DockingManager regionTarget)
    {
        region.Behaviors.Add(DockingBehavior.BehaviorKey,
            new DockingBehavior()
            {
                HostControl = regionTarget
            });

        base.AttachBehaviors(region, regionTarget);
    }

    protected override IRegion CreateRegion()
    {
        return new SingleActiveRegion();
    }
}
