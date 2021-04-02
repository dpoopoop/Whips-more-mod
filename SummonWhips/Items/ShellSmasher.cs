using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items
{
	public class ShellSmasher : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Shell Smasher");
			Tooltip.SetDefault(@"Works like a flail but with autoswing.
'Put the power of giant turtles in your hands'");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 1000);
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 10;
			item.useTime = 10;
			item.knockBack = 5f;
			item.damage = 210;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<ShellSmasherProj>();
			item.shootSpeed = 20f;
			item.UseSound = SoundID.Item1;
			item.summon = true;
			item.crit = 10;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)                 
        {
            player.AddBuff(ModContent.BuffType<Buffs.SummonTag>(), 75);
			{
            return true;
        }
        }

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TurtleShell, 1);
			recipe.AddIngredient(ItemID.BeetleHusk, 12);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
