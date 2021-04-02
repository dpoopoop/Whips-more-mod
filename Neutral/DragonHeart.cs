using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips;

namespace SummonWhips.Items.Neutral
{
	public class DragonHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases max life by 50" +
			"\nAll attacks put betsys curse on enemies");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 36;
			item.value = Item.sellPrice(silver: 1000);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			NeutralPlayer modPlayer = NeutralPlayer.ModPlayer(player);
			player.statLifeMax2 += 50;
			player.GetModPlayer<WhipPlayer>().ichorItem = true;
		}
	}
}