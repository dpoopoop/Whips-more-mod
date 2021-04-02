using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace SummonWhips.Items.Others
{
	[AutoloadEquip(EquipType.Body)]
	internal class LightningSuit : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Lightning Suit");
			Tooltip.SetDefault("Increases summon damage by 10%"
			+ "\nIncreases max number of minions by 1");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 18;
			item.value = Item.sellPrice(silver: 720);
			item.rare = ItemRarityID.Pink;
			item.defense = 12;
		}
		public override void UpdateEquip(Player player) {
			player.minionDamage *= 1.1f;
			player.maxMinions += 1;
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms) {
			drawHands = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CoreOfLightning>(), 1);
			recipe.AddIngredient(1225, 20);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}