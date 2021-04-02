using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class SolarVortexKnifeProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Solar Vortex Knife Projectile");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.EmeraldBolt);
			aiType = 124;
			projectile.penetrate = 5;
			projectile.melee = true;
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = 124;
			return true;
		}
	}
}