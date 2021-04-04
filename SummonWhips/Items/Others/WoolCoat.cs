using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace SummonWhips.Items.Others
{
	[AutoloadEquip(EquipType.Body)]
	internal class WoolCoat : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Wool Coat");
			Tooltip.SetDefault("Increases max number of minions by 1");
		}
		public override void SetDefaults() {
			item.width = 34;
			item.height = 30;
			item.value = 5000;
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player) {
			player.maxMinions += 1;
		}

		public override void SetMatch(bool male, ref int equipSlot, ref bool robes) {
			robes = true;
			// The equipSlot is added in summonwhips.cs --> Load hook
			//equipSlot = mod.GetEquipSlot("WoolCoat_Legs", EquipType.Legs);
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms) {
			drawHands = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Wool>(), 4);
			recipe.AddIngredient(225, 5);
			recipe.AddIngredient(22, 6);
			recipe.anyIronBar = true;
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}