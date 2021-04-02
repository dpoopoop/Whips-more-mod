using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class WrathMeteor : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wrath Meteor");
		}

		public override void SetDefaults() {
			projectile.width = 30; 
            projectile.height = 30;
			projectile.aiStyle = 5; 
			aiType = 503;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.timeLeft = 300;
			projectile.friendly  = true;
		}
			public override void AI()
        {
			projectile.alpha = 0;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
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
		public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode.WithVolume(.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 5f, 0f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -5f, 0f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 0f, 5f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 3f, -3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -3f, 3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 3f, 3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -3f, -3f, 100, default, 3f);
        }
	}
}