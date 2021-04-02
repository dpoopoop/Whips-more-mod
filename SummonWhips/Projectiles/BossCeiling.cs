using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SummonWhips.Projectiles
{
	public class BossCeiling : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boss Ceiling"); 
		}

		public override void SetDefaults()
		{
			projectile.width = 1440;
			projectile.height = 90;
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

		