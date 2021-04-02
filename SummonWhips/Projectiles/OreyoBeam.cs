using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{	
	public class OreyoBeam : ModProjectile 
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ore-yo Beam");
		}
		public override void SetDefaults()
		{
			projectile.width = 16; 
			projectile.height = 16;
			projectile.penetrate = 1; 
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true; 
			projectile.melee = true;
			projectile.timeLeft = 60;
			projectile.aiStyle = 0; 
		}
		public override void AI()
		{
         for(int i = 0; i < 200; i++)
         {
           NPC target = Main.npc[i];
           float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
           float shootToY = target.position.Y - projectile.Center.Y;
           float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
           if(distance < 80f && !target.friendly && target.active)
            {
               distance = 3f / distance;
               shootToX *= distance * 5;
               shootToY *= distance * 5;
               projectile.velocity.X = shootToX;
               projectile.velocity.Y = shootToY;
            }
          } 
		 }
	   public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
            target.AddBuff(72, 10 * 60);
			target.AddBuff(169, 10 * 60);
		}
    }
}

		
	

