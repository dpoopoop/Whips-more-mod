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
	public class Ultimatum : NeutralClass
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ultimatum");
			Tooltip.SetDefault(@"Shoots a spread of bullets that go through walls.
'We still wonder: Isn't it TOO OP?");
		}

		public override void SafeSetDefaults() {
			item.damage = 150; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 64; // hitbox width of the item
			item.height = 32; // hitbox height of the item
			item.useTime = 50; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 50; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 2000); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Red; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item38; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<UltShot>(); 
			item.shootSpeed = 30f; // the speed of the projectile (measured in pixels per frame)
			item.crit = 5;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 8;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
				float scale = 1f - (Main.rand.NextFloat() * .5f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}