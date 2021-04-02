using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class OreoObliterator : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Charges up a cream beam.
'Eats up your mana the same way you eat oreos'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 800;
			item.noMelee = true;
			item.magic = true;
			item.channel = true;
			item.mana = 15;
			item.rare = ItemRarityID.Purple;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<OreoBeam>();
			item.value = 2700000;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OreoBar>(), 18);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}