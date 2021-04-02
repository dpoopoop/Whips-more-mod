using Terraria;
using Terraria.ModLoader;
using SummonWhips.NPCs;

namespace SummonWhips.Buffs
{
    public class Rainbow : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rainbow");
            Description.SetDefault("Taking damage");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<WhipGlobalNPC>().rainbowBuff = true;
            var dust = Dust.NewDustDirect(npc.position, 5, 5, 181, npc.velocity.X * Main.rand.Next(-5, 5), npc.velocity.Y * Main.rand.Next(-5, 5), 100, default, 1f);
            Dust.NewDustDirect(npc.position, 5, 5, 204, npc.velocity.X * Main.rand.Next(-5, 5), npc.velocity.Y * Main.rand.Next(-5, 5), 100, default, 1f);
            Dust.NewDustDirect(npc.position, 5, 5, 272, npc.velocity.X * Main.rand.Next(-5, 5), npc.velocity.Y * Main.rand.Next(-5, 5), 100, default, 1f);
            Dust.NewDustDirect(npc.position, 5, 5, 106, npc.velocity.X * Main.rand.Next(-5, 5), npc.velocity.Y * Main.rand.Next(-5, 5), 100, default, 1f);
            Dust.NewDustDirect(npc.position, 5, 5, 111, npc.velocity.X * Main.rand.Next(-5, 5), npc.velocity.Y * Main.rand.Next(-5, 5), 100, default, 1f);
            dust.noGravity = true;
        }
    }
}