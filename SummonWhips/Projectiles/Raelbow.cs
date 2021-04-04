using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SummonWhips.Projectiles
{	
	public class Raelbow : ModProjectile 
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Raelbow");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 100;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		public override void SetDefaults()
		{
			projectile.width = 16; 
			projectile.height = 16;
			projectile.penetrate = 1; 
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true; 
			projectile.magic = true;
			projectile.timeLeft = 4000;
			projectile.aiStyle = 1; 
			projectile.extraUpdates = 5;
			projectile.alpha = 64;
			projectile.light = 1.5f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			target.AddBuff(ModContent.BuffType<Buffs.Rainbow>(), 10 * 60);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 181, Main.rand.Next(-5, 5), Main.rand.Next(-6, 3), 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 204, Main.rand.Next(-5, 5), Main.rand.Next(-6, 3), 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 272, Main.rand.Next(-5, 5), Main.rand.Next(-6, 3), 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 106, Main.rand.Next(-5, 5), Main.rand.Next(-6, 3), 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 111, Main.rand.Next(-5, 5), Main.rand.Next(-6, 3), 100, default, 2f);
			if((!projectile.usesLocalNPCImmunity) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}
		public override void AI()
		{
         for(int i = 0; i < 200; i++)
         {
           NPC target = Main.npc[i];
         {
           float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
           float shootToY = target.position.Y - projectile.Center.Y;
           float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
           if(distance < 64f && !target.friendly && target.active)
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
}

		
	

