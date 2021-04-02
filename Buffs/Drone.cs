using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles.Minions;

namespace SummonWhips.Buffs
{
    public class Drone : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Swarm Drone");
			Description.SetDefault("The swarm drone will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ModContent.ProjectileType<SwarmDrone>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}