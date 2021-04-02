using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Buffs;
using SummonWhips.Items.Others;
using SummonWhips.NPCs;

namespace SummonWhips.Projectiles.Minions
{
	public class FlamingMeteor : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 5;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
			projectile.light = 1.5f;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; 
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			WhipPlayer modPlayer = player.GetModPlayer<WhipPlayer>();
			if (player.dead)
			{
				modPlayer.memePet = false;
			}
			if (modPlayer.memePet)
			{
				projectile.timeLeft = 2;
			}

			for(int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                if(distance < 320f && !target.friendly && target.active)
                {
                    if(projectile.ai[0] > 15f)
                    {
                        distance = 3f / distance;
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;
                        int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, 15, 500, projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Main.projectile[proj].timeLeft = 300;
                            Main.projectile[proj].netUpdate = true;
                            projectile.netUpdate = true;
                        Main.PlaySound(SoundID.DD2_BetsyFireballShot);
                        projectile.ai[0] = -50f;
                    }
                }
                }
            projectile.ai[0] += 1f;
		}
	}
}
