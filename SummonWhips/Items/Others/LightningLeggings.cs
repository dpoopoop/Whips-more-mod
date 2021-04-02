using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace SummonWhips.Items.Others
{
	[AutoloadEquip(EquipType.Legs)]
	public class LightningLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases summon damage and movement speed by 10%"
			+ "\nIncreases max number of minions by 1");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(silver: 660);
			item.rare = ItemRarityID.Pink;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player) {
			player.minionDamage *= 1.1f;
			player.maxMinions += 1;
			player.moveSpeed += 0.1f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CoreOfLightning>(), 1);
			recipe.AddIngredient(1225, 16);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

