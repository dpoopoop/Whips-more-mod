using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{	
	public class MagicFireball : ModProjectile 
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magic Fireball");
			Main.projFrames[projectile.type] = 4; 
		}
		public override void SetDefaults()
		{
			projectile.width = 18; 
			projectile.height = 18;
			projectile.penetrate = 1; 
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true; 
			projectile.magic = true;
			projectile.timeLeft = 180;
			projectile.aiStyle = 1; 
			aiType = 635;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
         {
			target.AddBuff(24, 3 * 60);
		 }
		public override void AI()
        {
            if (++projectile.frameCounter >= 5) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4) 
                {
					projectile.frame = 0;
				}
			}
		}
    }
}

		
	

