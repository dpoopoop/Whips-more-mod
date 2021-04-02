using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items
{
	public class ShroomiteStar : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Shroomite Star");
			Tooltip.SetDefault(@"Works like a flail but with autoswing.
'This whip is surprisingly cold'");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 600);
			item.rare = ItemRarityID.Lime;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 7.5f;
			item.damage = 200;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<ShroomiteStarProj>();
			item.shootSpeed = 22f;
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
			recipe.AddIngredient(ItemID.Chain, 160);
			recipe.AddIngredient(ItemID.SpikyBall, 30);
			recipe.AddIngredient(ItemID.ShroomiteBar, 20);
			recipe.AddTile(247);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
