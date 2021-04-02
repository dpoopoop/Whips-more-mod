using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using SummonWhips.Projectiles;

namespace SummonWhips.Projectiles
{	
	public class MeteorSquare : ModProjectile 
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor Square"); 
		}

		public override void SetDefaults()
		{
			projectile.width = 40; 
			projectile.height = 40; 
			projectile.timeLeft = 300; 
			projectile.penetrate = 10; 
			projectile.friendly = true; 
			projectile.tileCollide = true; 
			projectile.ignoreWater = true; 
			projectile.melee = true; 
			projectile.aiStyle = 0; 
		}
		
		public override void AI()
        {
		    Player owner = Main.player[projectile.owner];
            projectile.light = 1f; 
            projectile.rotation += (float)projectile.direction * 0.2f;
            var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, default, 3f);
			dust.noGravity = true;
			dust.velocity /= 2f; 
			if(projectile.timeLeft % 15 == 0)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, MathHelper.Lerp(-30f, 30f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-30f, 30, (float)Main.rand.NextDouble()), mod.ProjectileType("SquareBeam"), 500, 1, Main.myPlayer);
            }
        }
    
	}
}
