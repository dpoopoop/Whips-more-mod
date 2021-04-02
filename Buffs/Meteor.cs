using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles.Minions;

namespace SummonWhips.Buffs
{
	public class Meteor : ModBuff
	{
		public override void SetDefaults()
		{
			Description.SetDefault("The meteor will protect you");
			DisplayName.SetDefault("Meteor");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<WhipPlayer>().memePet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("FlamingMeteor")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("FlamingMeteor"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}