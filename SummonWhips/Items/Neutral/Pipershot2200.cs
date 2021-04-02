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
	public class Pipershot2200 : NeutralClass
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pipershot 2200");
			Tooltip.SetDefault(@"Shoots an awesome laser beam.
'Boom! You're dead!'");
		}

		public override void SafeSetDefaults() {
			item.damage = 350; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 64; // hitbox width of the item
			item.height = 32; // hitbox height of the item
			item.useTime = 32; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 32; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 2000); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Red; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item72; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<PiperBeam>(); 
			item.shootSpeed = 25f; // the speed of the projectile (measured in pixels per frame)
			item.crit = 20;
		}
	}
}