using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Buffs
{
    public class ArmorMelt : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Armor Melter");
            Description.SetDefault("Allows you to penetrate armor");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.armorPenetration += 100;
        }
    }
}