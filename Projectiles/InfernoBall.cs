using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Projectiles
{
	public class InfernoBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Ball");
		}

		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			aiType = 711;
		}
		public override void AI() 
		{
			Lighting.AddLight(projectile.position, 2.55f, 2.55f, 1.45f);
			var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, default, 1.75f);
			dust = Main.dust[Terraria.Dust.NewDust(projectile.position, 30, 30, 136, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 0, new Color(255,255,255), 1f)];
			dust.noGravity = true;
			dust.velocity /= 2f;
		if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 285)
		{
            projectile.velocity.Y = projectile.velocity.Y + 0.05f;
		}
		if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 280)
		{
            projectile.velocity.Y = projectile.velocity.Y + 0.10f;
		}
		if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 275)
		{
            projectile.velocity.Y = projectile.velocity.Y + 0.10f;
		}
		if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 270)
		{
            projectile.velocity.Y = projectile.velocity.Y + 0.10f;
		}
		if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 265)
		{
            projectile.velocity.Y = projectile.velocity.Y + 0.25f;
		}
		if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 260)
		{
            projectile.velocity.Y = projectile.velocity.Y + 0.15f;
		}

		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)       
        {
            target.AddBuff(ModContent.BuffType<Buffs.MeltedArmor>(), 10 * 60);
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.DD2_BetsyFireballImpact.WithVolume(.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
			Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("Explode"), 150 * (int)owner.magicDamage, 0, Main.myPlayer);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87, 5f, 0f, 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87, -5f, 0f, 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87, 0f, 5f, 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87, 0f, -5f, 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87, 3f, 3f, 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87, -3f, 3f, 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87, -3f, -3f, 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87, 3f, -3f, 100, default, 2f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 5f, 0f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -5f, 0f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 0f, 5f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 3f, -3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -3f, 3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 3f, 3f, 100, default, 3f);
			Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -3f, -3f, 100, default, 3f);
        }
	}
}