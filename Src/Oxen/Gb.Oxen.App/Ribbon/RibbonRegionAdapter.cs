using Prism.Regions;

namespace Gb.Oxen.App.Ribbon
{
    public class RibbonRegionAdapter : RegionAdapterBase<Fluent.Ribbon>
	{
		public RibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
			: base(regionBehaviorFactory)
		{
		}

		protected override void Adapt(IRegion region, Fluent.Ribbon regionTarget)
		{
			region.Behaviors.Add(RibbonBehavoir.BehaviorKey,
				new RibbonBehavoir()
				{
					MainRibbon = regionTarget
				});

			base.AttachBehaviors(region, regionTarget);
		}

		protected override IRegion CreateRegion()
		{
			return new SingleActiveRegion();
		}

	}
}
