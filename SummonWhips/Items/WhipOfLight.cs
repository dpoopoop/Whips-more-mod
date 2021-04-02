using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items
{
	public class WhipOfLight : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Whip of Light");
			Tooltip.SetDefault(@"Works like a flail but with autoswing.
'Who thought pearlwood was useless?'");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 100);
			item.rare = ItemRarityID.LightRed;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 10;
			item.useTime = 10;
			item.knockBack = 5f;
			item.damage = 70;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<WhipOfLightProj>();
			item.shootSpeed = 17f;
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
			recipe.AddIngredient(ItemID.Chain, 80);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.Pearlwood, 50);
			recipe.anyWood = false;
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
