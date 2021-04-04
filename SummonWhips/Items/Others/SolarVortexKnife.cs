using Microsoft.Xna.Framework;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class SolarVortexKnife : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Left click to shoot projectiles!
Right click to stab!");
		}

		public override void SetDefaults() {
			item.damage = 150;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = 1000000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(24, 180);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex, 12);
			recipe.AddIngredient(ItemID.FragmentSolar, 12);
			recipe.AddRecipeGroup("Butterflies", 4);
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
				item.useTime = 7;
				item.useAnimation = 7;
				item.damage = 150;
				item.shoot = ProjectileID.None;
				
			}
			else {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 30;
				item.useAnimation = 20;
				item.damage = 150;
				item.shoot = ModContent.ProjectileType<SolarVortexKnifeProj>();
				
			}
			return base.CanUseItem(player);
			
			}
		}
}