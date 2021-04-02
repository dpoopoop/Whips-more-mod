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
	public class NewPistol : NeutralClass
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to use alternate melee attack");
		}

		public override void SafeSetDefaults() {
			item.damage = 45; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 30; // hitbox width of the item
			item.height = 16; // hitbox height of the item
			item.useTime = 18; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 18; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 700); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.LightRed; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<BadProjectile>(); 
			item.shootSpeed = 15f; // the speed of the projectile (measured in pixels per frame)
		}
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
	    {	 
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			int rand = Main.rand.Next(5); //Generates an integer from 0 to 1
            if(rand == 0)
			{
			int numberProjectiles = 5;
			Main.PlaySound(SoundID.Item36);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
			    float scale = 1f - (Main.rand.NextFloat() * .3f);
			    perturbedSpeed = perturbedSpeed * scale;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			}
			return false;
	    }
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.HoldingOut; //melee mode
				item.noUseGraphic = true;
				item.channel = true;
				item.damage = 50;
				item.useAnimation = 23;
				item.useTime = 23;
				item.knockBack = 6;
				item.shootSpeed = 6f;
				item.UseSound = SoundID.Item1;
				item.shoot = ModContent.ProjectileType<NewMelee>();
			}
			else {
				item.useStyle = ItemUseStyleID.HoldingOut; //gun mode
				item.useTime = 20;
				item.useAnimation = 18;
				item.damage = 50;
				item.useTime = 18;
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