using Terraria.ModLoader;
using SummonWhips.NPCs.Boss;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using SummonWhips.NPCs;
using SummonWhips.Items.Others;

namespace SummonWhips
{
	public class SummonWhips : Mod
	{
		public override void PostSetupContent() {
			// Showcases mod support with Boss Checklist without referencing the mod
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) 
			{
				bossChecklist.Call(
					"AddBoss",
					13.1f,
					ModContent.NPCType<MeteorBoss>(),
					this,
					"Corite Knight",
					(Func<bool>)(() => SummonWhipsnpcWorld.DownedMeteorBoss),
					ModContent.ItemType<Items.Others.CelestialMeteor>(),
					new List<int> { ModContent.ItemType<Items.Others.MeteorBossTrophy>(), ModContent.ItemType<Items.Others.FireballTrophy>() },
					new List<int> { ModContent.ItemType<Items.Others.MeteorCore>(), ModContent.ItemType<Items.Others.MeteorShard>(), ModContent.ItemType<Items.Others.MeteorSquarePlane>(), ModContent.ItemType<Items.Others.MeteorInferno>(), ModContent.ItemType<Items.Others.MeteorEmblem>(), ModContent.ItemType<Items.Others.MeteorInABottle>(), ModContent.ItemType<Items.Others.MeteorWings>(), ItemID.FragmentSolar },
					$"Use a [i:{ModContent.ItemType<Items.Others.CelestialMeteor>()}]"
				);
			}
			Mod yabhb = ModLoader.GetMod("FKBossHealthBar");
            if (yabhb != null)
            {
            Call("RegisterDD2HealthBar", ModContent.NPCType<MeteorBoss>() );
            Call("RegisterHealthBarMini", ModContent.NPCType<NPCs.oreo>() );
            }
		}

	}
}
        
	
