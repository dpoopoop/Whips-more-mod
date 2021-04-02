using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.NPCs
{

	
	public class oreo : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Oreo");
		}

		public override void SetDefaults() {
			npc.width = 48;
			npc.height = 48;
			npc.damage = 50;
			npc.defense = 20;
			npc.lifeMax = 10000;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 1000f;
			npc.knockBackResist = 0.2f;
			npc.noGravity = true;
			npc.aiStyle = 74;
			aiType = NPCID.SolarCorite;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return !spawnInfo.playerSafe && SummonWhipsnpcWorld.DownedMeteorBoss ? SpawnCondition.OverworldNightMonster.Chance * 0.15f : 0f;
		}
		
		public override void NPCLoot()
        {
			int choice = Main.rand.Next(2);
            if (choice == 0)
        {
	        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OreoCookieOre"), Main.rand.Next(8, 16));
        }
            else if (choice == 1)
        {
	        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OreoCreamOre"), Main.rand.Next(4, 8));
        }
	       
        }

	}
}