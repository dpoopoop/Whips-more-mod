using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Items.Others;

namespace SummonWhips.Items.Others
{
	public class OreoBar : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'It looks delicious'");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 30;
			item.maxStack = 999;
			item.value = 150000;
			item.rare = ItemRarityID.Purple;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OreoCookieOre>(), 4);
			recipe.AddIngredient(ModContent.ItemType<OreoCreamOre>(), 2);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
