using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace SummonWhips.Items.Others
{
	public class CoreOfLightning : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'The core of thunderstorm clouds'");
		}

		public override void SetDefaults() {
			item.width = 16;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(silver: 100);
			item.rare = ItemRarityID.Pink;
		}

	}
}
