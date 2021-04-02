using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class NeonKnifeProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Neon Knife Projectile");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.AmethystBolt);
			aiType = 121;
			projectile.penetrate = 8;
			projectile.melee = true;
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = 121;
			return true;
		}
	}
}