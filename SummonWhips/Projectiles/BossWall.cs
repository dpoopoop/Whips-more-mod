using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SummonWhips.Projectiles
{
	public class BossWall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boss Wall"); 
		}

		public override void SetDefaults()
		{
			projectile.width = 90;
			projectile.height = 1440;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = -1; // -1 = infinity
			projectile.timeLeft = 1200;
			projectile.aiStyle = 0;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}
	}
}

		