using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using SummonWhips;

namespace SummonWhips.Items.Others
{
	public class ArcrisMeteor : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Place it in your inventory to make the Corite Knight look better'");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Red;
		}
		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<WhipPlayer>().coriteArcri = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(116, 5);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
