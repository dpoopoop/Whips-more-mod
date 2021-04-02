using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using SummonWhips.Projectiles.Minions;

namespace SummonWhips.Projectiles.Minions
{
	public class GhastBall : ModProjectile
	{
		public override void SetDefaults()
        {
            projectile.width = 24; 
            projectile.height = 24; 
            projectile.aiStyle = 0; 
            projectile.friendly  = true; 
            projectile.minion = true; 
            projectile.timeLeft = 600; 
			projectile.penetrate = 1;
			projectile.tileCollide = true; 
			projectile.ignoreWater = true;
        }
		public override void AI()
        {
			projectile.light = 1f; 
            projectile.rotation += 0.5f;
			var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 0, 0, 100, default, 3f);
			dust.noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) 
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(62, projectile.position);
			return true;
		}
		public override void Kill(int timeLeft)
        {
			Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("GhastExplosion"), 80 * (int)owner.minionDamage, 0, Main.myPlayer);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 5f, 0f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -5f, 0f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 0f, 5f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 0f, -5f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 3f, -3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -3f, 3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 3f, 3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -3f, -3f, 100, default, 3f);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) 
		{
			target.AddBuff(24, 5 * 60);
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}
	}
}