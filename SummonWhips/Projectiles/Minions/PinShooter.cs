using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;
 
namespace SummonWhips.Projectiles.Minions      
 
{
    public class PinShooter : ModProjectile
    {
 
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
 
            Main.PlaySound(2, projectile.Center, 62);  
 
            for (int i = 0; i < 20; i++) 
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 58, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 3.50f);   
                Main.dust[dust].noGravity = false; 
                Main.dust[dust].velocity *= 2.5f;
            }
        }
 
        public override void AI()
        {       
            Main.player[projectile.owner].UpdateMaxTurrets();
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
                
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
 
                
                if (distance < 400f && !target.friendly && target.active)  
                {
                    if (projectile.ai[0] > 80f) //2 seconds fire rate
                    {
                        
                        distance = 1.6f / distance;
 
                        
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 18;                  
                        
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5, -0.5f, mod.ProjectileType("Pin"), damage, 6f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5, -0.5f, mod.ProjectileType("Pin"), damage, 6f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 5, mod.ProjectileType("Pin"), damage, 6f, Main.myPlayer, 0f, 0f); 
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -5, mod.ProjectileType("Pin"), damage, 6f, Main.myPlayer, 0f, 0f); 
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 3, -4, mod.ProjectileType("Pin"), damage, 6f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -3, -4, mod.ProjectileType("Pin"), damage, 6f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -3, 2, mod.ProjectileType("Pin"), damage, 6f, Main.myPlayer, 0f, 0f); 
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 3, 2, mod.ProjectileType("Pin"), damage, 6f, Main.myPlayer, 0f, 0f); 
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 5); // is the sound
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
 
        }
    }
}
