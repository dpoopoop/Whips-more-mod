using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SummonWhips.Items.Others
{
	[AutoloadEquip(EquipType.Head)]
	public class WoolHat : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases summon damage by 3%");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 14;
			item.value = 4000;
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}
		public override void UpdateEquip(Player player) {
			player.minionDamage *= 1.03f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<WoolCoat>() && legs.type == ModContent.ItemType<WoolPants>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases max number of minions by 1";
			player.maxMinions += 1;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Wool>(), 3);
			recipe.AddIngredient(225, 4);
			recipe.AddIngredient(22, 5);
			recipe.anyIronBar = true;
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
