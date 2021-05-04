using ExpandedWeapons.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace ExpandedWeapons.Buffs
{
	public class SoulThiefBuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture) {
			// NPC only buff so we'll just assign it a useless buff icon.
			texture = "ExpandedWeapons/Buffs/Pointy";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults() {
			DisplayName.SetDefault("Soul Thief");
			Description.SetDefault("Losing life");
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NPCs.SummonGunNPC>().gunThief = true;
		}
	}
}