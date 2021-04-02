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
	public class BadPistol : NeutralClass
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to use alternate melee attack");
		}

		public override void SafeSetDefaults() {
			item.damage = 20; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 26; // hitbox width of the item
			item.height = 18; // hitbox height of the item
			item.useTime = 20; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 200); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<BadProjectile>(); 
			item.shootSpeed = 15f; // the speed of the projectile (measured in pixels per frame)
		}
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.HoldingOut; //melee mode
				item.noUseGraphic = true;
				item.channel = true;
				item.damage = 20;
				item.useAnimation = 25;
				item.useTime = 25;
				item.knockBack = 6;
				item.shootSpeed = 4f;
				item.UseSound = SoundID.Item1;
				item.shoot = ModContent.ProjectileType<BadMelee>();
			}
			else {
				item.useStyle = ItemUseStyleID.HoldingOut; //gun mode
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 20;
				item.useTime = 20;
				item.knockBack = 2;
				item.channel = false;
				item.noUseGraphic = false;
				item.shootSpeed = 15f;
				item.UseSound = SoundID.Item11;
				item.shoot = ModContent.ProjectileType<BadProjectile>();
			}
			return base.CanUseItem(player);
		
			}
		}
}