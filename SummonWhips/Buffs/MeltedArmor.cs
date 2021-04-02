using Terraria;
using Terraria.ModLoader;

namespace SummonWhips.Buffs
{
    public class MeltedArmor : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Melted Armor");
            Description.SetDefault("Defense reduced by 100");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense -= 100;
            var dust = Dust.NewDustDirect(npc.position, 5, 5, 127, npc.velocity.X * Main.rand.Next(3), npc.velocity.Y * Main.rand.Next(3), 100, default, 1.75f);
            dust.noGravity = true;
        }
    }
}