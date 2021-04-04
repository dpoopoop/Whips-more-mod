using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class MeteorCore : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'The energy in this object feels like it's on overdrive'");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 1000000;
			item.rare = ItemRarityID.Red;
		}

	}
}
