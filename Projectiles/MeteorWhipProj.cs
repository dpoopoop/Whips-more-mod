using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SummonWhips.Projectiles
{
	public class MeteorWhipProj : ModProjectile
	{
		// chain texture
		private const string ChainTexturePath = "SummonWhips/Gores/MeteorWhipChn";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor Projectile"); 
		}

		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.friendly = true;
			projectile.penetrate = -1; // -1 = infinity
			projectile.minion = true;
		}
		
		public override void AI()
		{
			// PARTICLES
			var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, default, 3f);
			dust.noGravity = true;
			dust.velocity /= 2f;

			var player = Main.player[projectile.owner];

			
			if (player.dead) {
				projectile.Kill();
				return;
			}

			// attack speed
			player.itemAnimation = 5;
			player.itemTime = 5;

			
			int newDirection = projectile.Center.X > player.Center.X ? 1 : -1;
			player.ChangeDir(newDirection);
			projectile.direction = newDirection;

			var vectorToPlayer = player.MountedCenter - projectile.Center;
			float currentChainLength = vectorToPlayer.Length();

			
			if (projectile.ai[0] == 0f) {
				// max range
				float maxChainLength = 320f;
				projectile.tileCollide = false;

				if (currentChainLength > maxChainLength) {
					
					projectile.ai[0] = 1f;
					projectile.netUpdate = true;
				}
				else if (!player.channel) {
					
					if (projectile.velocity.Y < 0f)
						projectile.velocity.Y *= 1f;

					projectile.velocity.Y += 0.1f;
					projectile.velocity.X *= 1f;
				}
			}
			else if (projectile.ai[0] == 1f) {
				
				float elasticFactorA = 14f / player.meleeSpeed;
				float elasticFactorB = 10f / player.meleeSpeed;
				float maxStretchLength = 314f; // number is max range - 6

				if (projectile.ai[1] == 1f)
					projectile.tileCollide = false;

				
				if (!player.channel || currentChainLength > maxStretchLength || !projectile.tileCollide) {
					projectile.ai[1] = 1f;

					if (projectile.tileCollide)
						projectile.netUpdate = true;

					projectile.tileCollide = false;

					if (currentChainLength < 20f)
						projectile.Kill();
				}

				if (!projectile.tileCollide)
					elasticFactorB *= 2f;

				int restingChainLength = 60;

				
				if (currentChainLength > restingChainLength || !projectile.tileCollide) {
					var elasticAcceleration = vectorToPlayer * elasticFactorA / currentChainLength - projectile.velocity;
					elasticAcceleration *= elasticFactorB / elasticAcceleration.Length();
					projectile.velocity *= 1f;
					projectile.velocity += elasticAcceleration;
				}
				else {
					
					if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 6f) {
						projectile.velocity.X *= 0.96f;
						projectile.velocity.Y += 0.1f;
					}
					if (player.velocity.X == 0f)
						projectile.velocity.X *= 0.96f;
				}
			}

			
			projectile.rotation = vectorToPlayer.ToRotation() - projectile.velocity.X * 0.1f;

			//Debuufs
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			Player player = Main.player[projectile.owner];
            target.AddBuff(69, 3 * 60);
			target.AddBuff(189, 10 * 60);
			target.AddBuff(204, 3 * 60);
			target.AddBuff(24, 10 * 60);
			{
        
               {
				   Player owner = Main.player[projectile.owner];
                   Projectile.NewProjectile(projectile.position.X +36, projectile.position.Y - 600, projectile.velocity.X * 0, projectile.velocity.Y + 30, mod.ProjectileType("MeteorProjectile"), 150 * (int)owner.minionDamage, projectile.knockBack, Main.myPlayer); 
				   Projectile.NewProjectile(projectile.position.X -36, projectile.position.Y - 600, projectile.velocity.X * 0, projectile.velocity.Y + 30, mod.ProjectileType("MeteorProjectile"), 150 * (int)owner.minionDamage, projectile.knockBack, Main.myPlayer);
               }
            }
}
			
        
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			
			bool shouldMakeSound = false;

			if (oldVelocity.X != projectile.velocity.X) {
				if (Math.Abs(oldVelocity.X) > 4f) {
					shouldMakeSound = true;
				}

				projectile.position.X += projectile.velocity.X;
				projectile.velocity.X = -oldVelocity.X * 0.2f;
			}

			if (oldVelocity.Y != projectile.velocity.Y) {
				if (Math.Abs(oldVelocity.Y) > 4f) {
					shouldMakeSound = true;
				}

				projectile.position.Y += projectile.velocity.Y;
				projectile.velocity.Y = -oldVelocity.Y * 0.2f;
			}

			
			projectile.ai[0] = 1f;

			if (shouldMakeSound) {
				
				projectile.netUpdate = true;
				Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
				
			}

			return false;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			var player = Main.player[projectile.owner];

			Vector2 mountedCenter = player.MountedCenter;
			Texture2D chainTexture = ModContent.GetTexture(ChainTexturePath);

			var drawPosition = projectile.Center;
			var remainingVectorToPlayer = mountedCenter - drawPosition;

			float rotation = remainingVectorToPlayer.ToRotation() - MathHelper.PiOver2;

			if (projectile.alpha == 0) {
				int direction = -1;

				if (projectile.Center.X < mountedCenter.X)
					direction = 1;

				player.itemRotation = (float)Math.Atan2(remainingVectorToPlayer.Y * direction, remainingVectorToPlayer.X * direction);
			}

			// chains here
			while (true) {
				float length = remainingVectorToPlayer.Length();

				
				if (length < 25f || float.IsNaN(length))
					break;

				
				drawPosition += remainingVectorToPlayer * 12 / length;
				remainingVectorToPlayer = mountedCenter - drawPosition;

				
				Color color = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
				spriteBatch.Draw(chainTexture, drawPosition - Main.screenPosition, null, color, rotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
			}

			return true;
		}
	}
}