using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class Oreo : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Heals 50% of max life"
				+ "\n'I like oreos'");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/oreoeat");
			item.maxStack = 999;
			item.consumable = true;
			item.rare = ItemRarityID.Purple;
			item.healLife = 100; 
			item.potion = true; 
			item.value = Item.buyPrice(gold: 1);
		}

		public override void GetHealLife(Player player, bool quickHeal, ref int healValue) {
			healValue = player.statLifeMax2 / 2;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OreoBar>(), 1);
			recipe.AddIngredient(3544, 5);
			recipe.AddTile(355);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}