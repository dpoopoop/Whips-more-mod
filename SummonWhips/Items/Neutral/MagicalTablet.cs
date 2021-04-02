using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips;

namespace SummonWhips.Items.Neutral
{
	public class MagicalTablet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases movement speed by 15%" +
			"\nCritical hits release magical projectiles");
		}

		public override void SetDefaults() {
			item.width = 31;
			item.height = 27;
			item.value = Item.sellPrice(silver: 1000);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			NeutralPlayer modPlayer = NeutralPlayer.ModPlayer(player);
			player.moveSpeed += 0.15f;
			player.GetModPlayer<WhipPlayer>().randomDebuff = true;
		}
	}
}