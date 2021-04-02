using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class StripedButterflyKnife : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to stab!");
		}

		public override void SetDefaults() {
			item.damage = 60;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = 150000;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(31, 100);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LightShard, 1);
			recipe.AddIngredient(ItemID.DarkShard, 1);
			recipe.AddRecipeGroup("Butterflies", 2);
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.anyIronBar = true;
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.Stabbing;
				item.useTime = 9;
				item.useAnimation = 9;
				item.damage = 54;
			}
			else {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 18;
				item.useAnimation = 18;
				item.damage = 72;
			}
			return base.CanUseItem(player);
		

		
			}
		}
}