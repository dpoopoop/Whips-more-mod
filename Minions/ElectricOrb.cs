using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;
 
namespace SummonWhips.Projectiles.Minions      
{
    public class ElectricOrb : ModProjectile
    {
        public override void SetStaticDefaults() {
			Main.projFrames[projectile.type] = 5;
		}
        public override void SetDefaults()
        {
            projectile.width = 38; 
            projectile.height = 38;   
            projectile.hostile = false;  
            projectile.friendly = false; 
            projectile.ignoreWater = true;     
            projectile.penetrate = -1; 
            projectile.tileCollide = true; 
            projectile.minion = true; 
            projectile.alpha = 120;
        }
 
        public override void Kill(int timeLeft)
        {
 
            Main.PlaySound(2, projectile.Center, 8);  
 
            for (int i = 0; i < 20; i++) 
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 45, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 3.50f);   
                Main.dust[dust].noGravity = false; 
                Main.dust[dust].velocity *= 2.5f;
            }
        }
 
        public override void AI()
        {       
            if (Main.player[projectile.owner].GetModPlayer<WhipPlayer>().lightning == false)
            {
                projectile.Kill();
            }
            Player player = Main.player[projectile.owner];
            if (player.dead || !player.active) {
				player.ClearBuff(ModContent.BuffType<Buffs.ElectricOrb>());
			}
			if (player.HasBuff(ModContent.BuffType<Buffs.ElectricOrb>())) {
				projectile.timeLeft = 2;
			}
            projectile.Center = player.Center - new Vector2(0, 60);
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
 
                
                if (distance < 400f && !target.friendly && target.active)  
                {
                    if (projectile.ai[0] > 60f) //2 seconds fire rate
                    {
                        
                        distance = 1.6f / distance;
 
                        
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 100;                  
                        
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("ElectricBolt"), 100, 6f, Main.myPlayer, 0f, 0f); 
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 75); //75 is the sound
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
 
        }
    }
}
