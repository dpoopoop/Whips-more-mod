using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SummonWhips.Items.Neutral
{
	public class MagicHat : NeutralClass
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots random projectiles");
		}

		public override void SafeSetDefaults() {
			item.damage = 70;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = Item.sellPrice(silver: 800);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item85;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<GoldenBolt>();
			item.shootSpeed = 18f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
	    {
			int rand = Main.rand.Next(12);
            if(rand == 0)
			{
				item.shoot = ModContent.ProjectileType<GoldenBolt>();
			}
			    if(rand == 1)
			{
				item.shoot = 281;
			}
			   if(rand == 2)
			{
				item.shoot = 343;
			}
				if(rand == 3)
			{
				item.shoot = ModContent.ProjectileType<Pin>();
			}
				if(rand == 4)
			{
				item.shoot = 173;
			}
				if(rand == 5)
			{
				item.shoot = 183;
			}
				if(rand == 6)
			{
				item.shoot = 502;
			}
				if(rand == 7)
			{
				item.shoot = 227;
			}
				if(rand == 8)
			{
				item.shoot = 207;
			}
				if(rand == 9)
			{
				item.shoot = 248;
			}
				if(rand == 10)
			{
				item.shoot = 263;
			}
				if(rand == 11)
			{
				item.shoot = 294;
			}
			return true;
		}	 
			
	}
}