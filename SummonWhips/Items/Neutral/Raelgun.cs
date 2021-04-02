using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ModLoader;
using System;

namespace SummonWhips.Items.Neutral
{
	public class Raelgun : NeutralClass
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots a rainbow laser beam that does lasting damage.
'We're all innit!'");
		}

		public override void SafeSetDefaults() {
			item.damage = 100; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 64; // hitbox width of the item
			item.height = 32; // hitbox height of the item
			item.useTime = 55; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 55; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 1600); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Cyan; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item92; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<Raelbow>(); 
			item.shootSpeed = 12f; // the speed of the projectile (measured in pixels per frame)
			item.crit = 10;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
        }
	}
}