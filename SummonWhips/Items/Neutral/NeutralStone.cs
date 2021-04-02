using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Neutral
{
	public class NeutralStone : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("10% increased neutral damage" +
							   "\n5% increased damage");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.value = Item.sellPrice(silver: 200);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			NeutralPlayer modPlayer = NeutralPlayer.ModPlayer(player);
			modPlayer.neutralDamageMult *= 1.1f;
			player.allDamage += 0.05f;
		}
	}
}