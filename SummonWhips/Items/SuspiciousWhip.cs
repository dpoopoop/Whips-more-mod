using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items
{
	public class SuspiciousWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Suspicious Whip");
			Tooltip.SetDefault(@"Works like a flail but with autoswing.
'I don't know but this whip looks pretty sus to me'");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 1600);
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 8f;
			item.damage = 300;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<SuspiciousWhipProj>();
			item.shootSpeed = 25f;
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
			recipe.AddIngredient(ItemID.MartianConduitPlating, 100);
			recipe.AddIngredient(ItemID.AntiGravityHook, 1);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
