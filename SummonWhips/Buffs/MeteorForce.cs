using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Buffs
{
    public class MeteorForce : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Meteor Force");
            Description.SetDefault("25% increased minion damage");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.minionDamage *= 1.25F;
        }
    }
}