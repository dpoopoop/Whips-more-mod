using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{	
	public class Wave : ModProjectile 
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wave");
		}
		public override void SetDefaults()
		{
			projectile.width = 16; 
			projectile.height = 16;
			projectile.penetrate = 1; 
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true; 
			projectile.ranged = true;
			projectile.timeLeft = 300;
			projectile.aiStyle = 1; 
		}
		public override void AI()
		{
			var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 187, 0, 0, 100, default, 3f);
			dust.noGravity = true;
         for(int i = 0; i < 200; i++)
         {
           NPC target = Main.npc[i];
           float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
           float shootToY = target.position.Y - projectile.Center.Y;
           float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
           if(distance < 160f && !target.friendly && target.active)
            {
               distance = 3f / distance;
               shootToX *= distance * 5;
               shootToY *= distance * 5;
               projectile.velocity.X = shootToX;
               projectile.velocity.Y = shootToY;
            }
          } 
		}
    }
}