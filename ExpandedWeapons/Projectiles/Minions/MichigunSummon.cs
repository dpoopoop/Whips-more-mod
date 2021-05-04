using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles.Minions
{
	// MichigunSummonWisp uses inheritace as an example of how it can be useful in modding.
	// HoverShooter and Minion classes help abstract common functionality away, which is useful for mods that have many similar behaviors.
	// Inheritance is an advanced topic and could be confusing to new programmers, see ExampleSimpleMinion.cs for a simpler minion example.
	public class MichigunSummon : HoverShooter
	{
		public override void SetStaticDefaults() {
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
		}

		public override void SetDefaults() {
			projectile.netImportant = true;
			projectile.width = 48;
			projectile.height = 48;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 3;
			inertia = 20f;
			shoot = ModContent.ProjectileType<MichigunSummonBeam>();
			shootSpeed = 12f;
		}

		public override void CheckActive() {
			Player player = Main.player[projectile.owner];
			ExpandedPlayer modPlayer = player.GetModPlayer<ExpandedPlayer>();
			if (modPlayer.summonPet == false)
            {
                projectile.Kill();
            }
			if (player.dead) {
				modPlayer.summonPet = false;
			}
			if (modPlayer.summonPet) { // Make sure you are resetting this bool in ModPlayer.ResetEffects. See ExamplePlayer.ResetEffects
				projectile.timeLeft = 2;
			}
		}

		public override void CreateDust() {
			if (projectile.ai[0] == 0f) {
				if (Main.rand.NextBool(5)) {
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 91);
					Main.dust[dust].velocity.Y -= 1.2f;
				}
			}
			else {
				if (Main.rand.NextBool(3)) {
					Vector2 dustVel = projectile.velocity;
					if (dustVel != Vector2.Zero) {
						dustVel.Normalize();
					}
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 91);
					Main.dust[dust].velocity -= 1.2f * dustVel;
				}
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.9f, 0.9f, 0.9f);
		}
	}
}