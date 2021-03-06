using SummonWhips.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Buffs
{
	public class Knife : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture) {
			// NPC only buff so we'll just assign it a useless buff icon.
			texture = "SummonWhips/Buffs/StarPower";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults() {
			DisplayName.SetDefault("Knife");
			Description.SetDefault("Losing life");
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.WhipGlobalNPC>().knifeSticked = true;
		}
	}
}