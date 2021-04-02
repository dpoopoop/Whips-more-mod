using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items
{
	public class WormWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Worm Whip");
			Tooltip.SetDefault(@"Works like a flail but with autoswing.
'It was a good idea to use the EoW's dead body as a weapon'");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 40);
			item.rare = ItemRarityID.Green;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 10;
			item.useTime = 10;
			item.knockBack = 4f;
			item.damage = 16;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<WormWhipProj>();
			item.shootSpeed = 16.5f;
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

		
	}
}
