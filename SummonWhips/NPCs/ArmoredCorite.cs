using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.NPCs
{

	
	public class ArmoredCorite : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Armored Corite");
		}

		public override void SetDefaults() {
			npc.width = 64;
			npc.height = 64;
			npc.damage = 70;
			npc.defense = 30;
			npc.lifeMax = 3000;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 1000f;
			npc.knockBackResist = 0.1f;
			npc.noGravity = true;
			npc.aiStyle = 74;
			aiType = NPCID.SolarCorite;
		}
		
		public override void NPCLoot()
        {
			if(Main.rand.Next(100) < 15)
           {
	        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MeteorShard"), 1);
           }
		}

	}
}