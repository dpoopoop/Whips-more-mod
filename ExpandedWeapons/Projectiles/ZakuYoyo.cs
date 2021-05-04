using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ExpandedWeapons.Projectiles
{
	public class ZakuYoyo : ModProjectile
	{
		public int laserCooldown;
		public override void SetStaticDefaults() {
			// Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite. (multiply by 2 because of extra-updates)
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			// Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 480f;
			// Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f (divide by 2 because of extra-updates)
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 19f;

			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults() {
			projectile.extraUpdates = 1;
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
			projectile.light = 0.5f;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 18;
		}
		public override void AI()
		{
			int damage = projectile.damage / 3;
			laserCooldown += 1;
			if (laserCooldown == 20)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, 0, ModContent.ProjectileType<BetterPurpleLaser>(), damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -5, 0, ModContent.ProjectileType<BetterPurpleLaser>(), damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 5, ModContent.ProjectileType<BetterPurpleLaser>(), damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -5, ModContent.ProjectileType<BetterPurpleLaser>(), damage, 0f, Main.myPlayer);
			}
			if (laserCooldown == 40)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 3, 3, ModContent.ProjectileType<BetterPurpleLaser>(), damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -3, 3, ModContent.ProjectileType<BetterPurpleLaser>(), damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -3, -3, ModContent.ProjectileType<BetterPurpleLaser>(), damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 3, -3, ModContent.ProjectileType<BetterPurpleLaser>(), damage, 0f, Main.myPlayer);
				laserCooldown = 0;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			if (crit == true)
			{
			target.AddBuff(44, 5 * 60);
			target.AddBuff(153, 5 * 60);
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}