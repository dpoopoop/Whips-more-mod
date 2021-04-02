using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class MeteorFighter : ModItem
	{
		public override void SetStaticDefaults() {
	    Tooltip.SetDefault(@"Converts bullets into meteors.
'Don't worry, It won't kill everything with seven shots'");
		}

		public override void SetDefaults() {
			item.damage = 150; 
			item.ranged = true; 
			item.width = 40; 
			item.height = 40; 
			item.useTime = 8; 
			item.useAnimation = 8; 
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.knockBack = 1; 
			item.value = 1500000; 
			item.rare = ItemRarityID.Purple; 
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/meteorpew");
			item.autoReuse = true; 
			item.shoot = 10;
			item.shootSpeed = 16f; 
			item.useAmmo = AmmoID.Bullet; 
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) {
				type = ModContent.ProjectileType<MeteorFighterProj>();
				item.damage = 800; }
				else
				{
				item.damage = 150; 
				}
			return true; 
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.MeteoriteBar, 50);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ModContent.ItemType<MeteorCore>(), 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}