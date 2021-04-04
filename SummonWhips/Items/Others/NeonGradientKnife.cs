using Microsoft.Xna.Framework;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class NeonGradientKnife : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Left click to shoot projectiles!
Right click to stab!");
		}

		public override void SetDefaults() {
			item.damage = 180;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = 2500000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 8f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(44, 180);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
			recipe.AddIngredient(ItemID.FragmentStardust, 15);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.ButterflyDust, 1);
			recipe.AddRecipeGroup("Butterflies", 5);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.Stabbing;
				item.useTime = 5;
				item.useAnimation = 5;
				item.damage = 180;
				item.shoot = ProjectileID.None;
				
			}
			else {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 15;
				item.useAnimation = 20;
				item.damage = 180;
				item.shoot = ModContent.ProjectileType<NeonKnifeProj>();
				
			}
			return base.CanUseItem(player);
			
			}
		}
}