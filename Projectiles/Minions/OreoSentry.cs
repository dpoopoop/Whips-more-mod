using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;
 
namespace SummonWhips.Projectiles.Minions      
 
{
    public class OreoSentry : ModProjectile
    {
         public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 11; 
        }
 
        public override void SetDefaults()
        {
            projectile.width = 64; 
            projectile.height = 64;   
            projectile.hostile = false;  
            projectile.friendly = false; 
            projectile.ignoreWater = true;  
            projectile.timeLeft = 7200;     
            projectile.penetrate = -1; 
            projectile.tileCollide = true; 
            projectile.sentry = true; 
        }
 
        public override void Kill(int timeLeft)
        {
            if (++projectile.frameCounter >= 12) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 11) 
                {
					projectile.frame = 0;
				}
			}
 
            Main.PlaySound(2, projectile.Center, 62);  
 
            for (int i = 0; i < 20; i++) 
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 51, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 3.50f);   
                Main.dust[dust].noGravity = false; 
                Main.dust[dust].velocity *= 2.5f;
            }
        }
 
        public override void AI()
        {
            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 51, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 1.50f);  
                Main.dust[dust].noGravity = true; 
                Main.dust[dust].velocity *= 0.9f;
            }
            
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
                
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
 
                
                if (distance < 800f && !target.friendly && target.active)  
                {
                    if (projectile.ai[0] > 120f) //2 seconds fire rate
                    {
                        
                        distance = 1.6f / distance;
 
                        
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 100;                  
                        
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX * 2, shootToY -5, mod.ProjectileType("OreoSentryProj"), damage, 6f, Main.myPlayer, 0f, 0f); 
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 28); //28 is the sound
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
 
        }
    }
}
