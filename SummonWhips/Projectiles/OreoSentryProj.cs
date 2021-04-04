using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using SummonWhips.Projectiles;

namespace SummonWhips.Projectiles
{
    public class OreoSentryProj : ModProjectile 
    {
        public override void SetDefaults()
        {
            projectile.width = 24; 
            projectile.height = 24; 
            projectile.aiStyle = 1; 
            projectile.friendly  = true; 
            projectile.minion = true; 
            projectile.timeLeft = 600; 
			projectile.penetrate = 1;
			projectile.tileCollide = true; 
			projectile.ignoreWater = true;
        }
		public override void AI()
		{
            projectile.rotation += (float)projectile.direction * 0.2f;
			Player owner = Main.player[projectile.owner];
			if(projectile.timeLeft % 7 == 0)
			{
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("OreoSpike"), 300, 1, Main.myPlayer);
			}
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