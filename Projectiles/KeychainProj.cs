using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SummonWhips.Projectiles
{
	public class KeychainProj : ModProjectile
	{
		// chain texture
		private const string ChainTexturePath = "SummonWhips/Gores/KeychainChn";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Keychain Projectile"); 
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.penetrate = -1; // -1 = infinity
			projectile.minion = true;
		}

		public override void AI()
		{
			// PARTICLES optional
			//var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, default, 1.5f);
			//dust.noGravity = true;
			//dust.velocity /= 2f;

			var player = Main.player[projectile.owner];

			// remove whip when die
			if (player.dead) {
				projectile.Kill();
				return;
			}

			// firerate
			player.itemAnimation = 22;
			player.itemTime = 22;

			// ROTATE
			int newDirection = projectile.Center.X > player.Center.X ? 1 : -1;
			player.ChangeDir(newDirection);
			projectile.direction = newDirection;

			var vectorToPlayer = player.MountedCenter - projectile.Center;
			float currentChainLength = vectorToPlayer.Length();

			if (projectile.ai[0] == 0f) {
				// Max range
				float maxChainLength = 96f;
				projectile.tileCollide = true;

				if (currentChainLength > maxChainLength) {
					// Max range hit = change
					projectile.ai[0] = 1f;
					projectile.netUpdate = true;
				}
				else if (!player.channel) {
					// gravity
					if (projectile.velocity.Y < 0f)
						projectile.velocity.Y *= 1f;

					projectile.velocity.Y += 0.1f;
					projectile.velocity.X *= 1f;
				}
			}
			else if (projectile.ai[0] == 1f) {
				// Retractable
				float elasticFactorA = 14f / player.meleeSpeed;
				float elasticFactorB = 2f / player.meleeSpeed;
				float maxStretchLength = 90f; // make this number 6 less than max range

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

			// spin 
			projectile.rotation = vectorToPlayer.ToRotation() - projectile.velocity.X * 0.1f;
		}

			// custom stuff here
			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//bouncy
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

			// its off the chain
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