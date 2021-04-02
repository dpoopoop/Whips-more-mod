using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles.Minions;

namespace SummonWhips.Buffs
{
    public class ElectricOrb : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Electric Orb");
			Description.SetDefault("The electric orb will zap nearby enemies");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

			public override void Update(Player player, ref int buffIndex) 
			{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.ElectricOrb>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
	}
}
}