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
	public class NerfBlaster : NeutralClass
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'These foam darts HURT.'");
		}

		public override void SafeSetDefaults() {
			item.damage = 31; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 31; // hitbox width of the item
			item.height = 22; // hitbox height of the item
			item.useTime = 30; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 30; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 200); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item17; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<NerfDart>(); 
			item.shootSpeed = 15f; // the speed of the projectile (measured in pixels per frame)
		}
	}
}