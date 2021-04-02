using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items
{
	public class StardustWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Stardust Whip");
			Tooltip.SetDefault(@"Works like a flail but with autoswing.
'Supercharge your minions with the power of the stars'");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 2000);
			item.rare = ItemRarityID.Red;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 10;
			item.useTime = 10;
			item.knockBack = 6f;
			item.damage = 250;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<StardustWhipProj>();
			item.shootSpeed = 30f;
			item.UseSound = SoundID.Item1;
			item.summon = true;
			item.crit = 10;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)                 
        {
            player.AddBuff(ModContent.BuffType<Buffs.StarPower>(), 75);
			{
            return true;
        }
        }

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentStardust, 20);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
