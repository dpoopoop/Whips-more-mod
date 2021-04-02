using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class MeteorProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Falling Meteor");
		}

		public override void SetDefaults() {
			projectile.width = 40; 
            projectile.height = 60;
			aiType = 15;
			projectile.penetrate = 2;
			projectile.minion = true;
			projectile.timeLeft = 100;
			projectile.friendly  = true;
		}
			public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = 15;
			return true;
		}
	}
}