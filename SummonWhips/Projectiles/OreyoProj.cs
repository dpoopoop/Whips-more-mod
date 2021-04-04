using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SummonWhips.Projectiles;

namespace SummonWhips.Projectiles
{
	public class OreyoProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 500f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18f;
		}

		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
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
		public override void PostAI() 
		{
			Player owner = Main.player[projectile.owner];
			if (Main.rand.NextBool()) 
			{		
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, MathHelper.Lerp(-3f, 3f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-5f, 5, (float)Main.rand.NextDouble()), mod.ProjectileType("OreyoBeam"), 100, 1, Main.myPlayer);
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 31);
				dust.noGravity = true;
				dust.scale = 1.2f;
			}
		}
	}
}