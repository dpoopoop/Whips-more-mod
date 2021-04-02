using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class MeteorShard : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'A shard that fell from a celestial meteor'");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 300000;
			item.rare = ItemRarityID.Red;
		}

		}
	}
