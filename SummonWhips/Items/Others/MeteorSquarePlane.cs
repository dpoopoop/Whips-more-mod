using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class MeteorSquarePlane : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Meteor Sqaure Plane");
			Tooltip.SetDefault(@"Throws a spinning square that spawns a projectile that shoots at the nearest enemy.
'Bring the heat'");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = Item.sellPrice(silver: 5000);
			item.rare = ItemRarityID.Purple;
			item.noMelee = true;
			item.useStyle = 1;
			item.useAnimation = 60;
			item.useTime = 60;
			item.knockBack = 5f;
			item.damage = 250;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<MeteorSquare>();
			item.shootSpeed = 2.5f;
			item.UseSound = SoundID.Item19;
			item.melee = true;
			item.autoReuse = true;
		}
	}
}
