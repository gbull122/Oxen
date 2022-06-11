using Fluent;
using Prism.Regions;

namespace Gb.Oxen.App.Ribbon
{
    public class BackstageRegionAdapter : RegionAdapterBase<Fluent.BackstageTabControl>
    {
        public BackstageRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, BackstageTabControl regionTarget)
        {
           
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
