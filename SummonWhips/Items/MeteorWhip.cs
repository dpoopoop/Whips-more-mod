using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Items.Others;

namespace SummonWhips.Items
{
	public class MeteorWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Corite on a Stick");
			Tooltip.SetDefault(@"Works like a flail but with autoswing.
'Put your minions on overdrive with the meteor force'");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 1500000;
			item.rare = ItemRarityID.Purple;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 8f;
			item.damage = 400;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<MeteorWhipProj>();
			item.shootSpeed = 30f;
			item.UseSound = SoundID.Item1;
			item.summon = true;
			item.crit = 10;
			item.autoReuse = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)                 
        {
            player.AddBuff(ModContent.BuffType<Buffs.MeteorForce>(), 75);
			{
            return true;
        }
        }

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.MeteoriteBar, 50);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddIngredient(ModContent.ItemType<MeteorCore>(), 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
