using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{	
	public class Magic4 : ModProjectile 
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magic 4");
			Main.projFrames[projectile.type] = 4; 
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
			projectile.timeLeft = 180;
			projectile.aiStyle = 1; 
			aiType = 635;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
         {
			target.AddBuff(70, 3 * 60);
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

		
	

