using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Buffs
{
    public class Resistance : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Resistance");
            Description.SetDefault("You are tough");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.noKnockback = true;
            player.endurance += 0.225f;
        }
    }
}