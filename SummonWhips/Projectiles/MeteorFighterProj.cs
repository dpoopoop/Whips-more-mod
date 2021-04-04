using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class MeteorFighterProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteor Ball");
		}

		public override void SetDefaults() {
			projectile.width = 22; 
            projectile.height = 12;
			projectile.aiStyle = 0;
			aiType = ProjectileID.Bullet;
			projectile.penetrate = 5;
			projectile.minion = true;
			projectile.timeLeft = 100;
			projectile.friendly  = true;
			projectile.alpha = 255;
		}
			public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.alpha > 0)
{
	        projectile.alpha -= 85;
}
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			target.AddBuff(69, 3 * 60);
			target.AddBuff(189, 10 * 60);
			target.AddBuff(204, 3 * 60);
			target.AddBuff(24, 10 * 60);
			
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}

		public override bool PreKill(int timeLeft) {
			return true;
		}
	}
}