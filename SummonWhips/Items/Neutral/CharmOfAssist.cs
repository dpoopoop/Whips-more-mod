using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Neutral
{
	public class CharmOfAssist : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases neutral damage by 10% and increases all damage by 5%" +
							   "\nIncreases the max number of minions and sentries by 1");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 20;
			item.value = Item.sellPrice(silver: 300);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			NeutralPlayer modPlayer = NeutralPlayer.ModPlayer(player);
			modPlayer.neutralDamageMult *= 1.1f;
			player.allDamage += 0.05f;
			player.maxTurrets += 1;
			player.maxMinions += 1;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<BandOfAssist>(), 1);
			recipe.AddIngredient(ModContent.ItemType<NeutralStone>(), 1);
            recipe.AddTile(114); 
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}