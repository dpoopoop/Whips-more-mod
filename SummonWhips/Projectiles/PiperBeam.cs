using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;
 
namespace SummonWhips.Projectiles   
 
{
    public class PiperBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24; 
            projectile.height = 24;   
            projectile.hostile = false;  
            projectile.friendly = true; 
            projectile.ignoreWater = true;  
            projectile.timeLeft = 300;     
            projectile.penetrate = -1; 
            projectile.tileCollide = true; 
            projectile.magic = true; 
            projectile.extraUpdates = 100;
        }
         public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 3f) 
            {
                for (int i = 0; i < 4; i++)
                {
                    projectile.alpha = 255;
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 180, 0, 0, 100, default, 2f);
                    var tete = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 180, 0, 0, 100, default, 2f);
			        dust.noGravity = true;
                    tete.noGravity = true;
                }
            }
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
 
        
