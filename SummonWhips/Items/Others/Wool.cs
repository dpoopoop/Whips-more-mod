using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class Wool : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Its so fluffy'");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = ItemRarityID.Blue;
		}

	}
}
