using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class GoldenBolt : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Golden Bolt");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.SapphireBolt);
			aiType = 123;
			projectile.penetrate = 1;
			projectile.magic = true;
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = 123;
			return true;
		}
	}
}