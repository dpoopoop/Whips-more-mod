using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class OreoSpike : ModProjectile
	{
		public override void SetDefaults()
        {
            projectile.width = 24; 
            projectile.height = 24; 
            projectile.aiStyle = 1; 
            projectile.friendly  = true; 
            projectile.minion = true; 
            projectile.timeLeft = 600; 
			projectile.penetrate = -1;
			projectile.tileCollide = true; 
			projectile.ignoreWater = true;
        }
		public override void AI()
        {
			projectile.light = 1f; 
            projectile.rotation += 0.5f;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) 
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(27, projectile.position);
			return true;
		}
		public override void Kill(int timeLeft)
        {
			Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("Boom"), 150 * (int)owner.minionDamage, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 5, 0, -3, mod.ProjectileType("OreoChase"), 100 * (int)owner.minionDamage, 0, Main.myPlayer);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) 
		{
			target.AddBuff(72, 10 * 60);
			target.AddBuff(169, 10 * 60);

			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}
	}
}