using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Buffs
{
    public class StarPower : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Star Power");
            Description.SetDefault("15% increased minion damage");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.minionDamage *= 1.15F;
        }
    }
}