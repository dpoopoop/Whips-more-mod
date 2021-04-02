using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles.Minions
{
	public class GhastExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghast Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 128;
			projectile.alpha = 255;
			projectile.height = 128;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.timeLeft = 10;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}
		public override void AI() 
		{
			projectile.light = 1f;
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