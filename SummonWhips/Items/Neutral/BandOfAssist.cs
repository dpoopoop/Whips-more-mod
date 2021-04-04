using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Neutral
{
	public class BandOfAssist : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases max number of minions and sentries by 1");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.value = Item.sellPrice(silver: 100);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			NeutralPlayer modPlayer = NeutralPlayer.ModPlayer(player);
			player.maxTurrets += 1;
			player.maxMinions += 1;
		}
	}
}