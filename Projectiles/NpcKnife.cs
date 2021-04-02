using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class NpcKnife : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("NPC Sim Knife");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			aiType = 48;
			projectile.width = 16;
			projectile.height = 16;
			projectile.penetrate = 1;
			projectile.melee = true;
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = 48;
			return true;
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
	}
}