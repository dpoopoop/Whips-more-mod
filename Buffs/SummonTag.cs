using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Buffs
{
    public class SummonTag : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Summon Tag");
            Description.SetDefault("10% increased minion damage");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.minionDamage *= 1.1F;
        }
    }
}