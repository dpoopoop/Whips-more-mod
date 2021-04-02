using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;
 
namespace SummonWhips.Projectiles    
 
{
    public class SolarBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 5; 
        }
 
        public override void SetDefaults()
        {
            projectile.width = 34; 
            projectile.height = 34;   
            projectile.hostile = false;  
            projectile.friendly = false; 
            projectile.ignoreWater = true;  
            projectile.timeLeft = 480;     
            projectile.penetrate = -1; 
            projectile.tileCollide = true; 
            projectile.magic = true; 
            projectile.alpha = 96;
            projectile.light = 1.5f;
        }
 
        public override void AI()
        {
            if (++projectile.frameCounter >= 6) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5) 
                {
					projectile.frame = 0;
				}
			}
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
                
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
 
                
                if (distance < 350f && !target.friendly && target.active)  
                {
                    if (projectile.ai[0] > 9f) //2 seconds fire rate
                    {
                        
                        distance = 1.6f / distance;
 
                        
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 96;                  
                        
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("SolarBeam"), damage, 6f, Main.myPlayer, 0f, 0f); 
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
 
        }
    }
}
