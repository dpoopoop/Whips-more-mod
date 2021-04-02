using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SummonWhips.Items.Others;
using SummonWhips.NPCs;
using SummonWhips.Buffs;
using SummonWhips.Projectiles;

namespace SummonWhips.NPCs
{
	public class WhipGlobalNPC : GlobalNPC
    {
    public override bool InstancePerEntity => true;

	public bool knifeSticked;
	public bool rainbowBuff;

	public override void ResetEffects(NPC npc) {
			knifeSticked = false;
			rainbowBuff = false;
		}
    public override void SetDefaults(NPC npc) {
			npc.buffImmune[ModContent.BuffType<Knife>()] = npc.buffImmune[BuffID.BoneJavelin];
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) 
		{
			if (knifeSticked) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				int knifeCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ModContent.ProjectileType<SimKnife>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) 
					{
						knifeCount++;
					}
				}
				npc.lifeRegen -= knifeCount * 2 * 3;
				if (damage < knifeCount * 3) 
				{
					damage = knifeCount * 3;
				}
			}
			if (rainbowBuff) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 800;
				if (damage < 100) {
					damage = 100;
				}
			}
		}
	public override void SetupShop(int type, Chest shop, ref int nextSlot) 
	{
			if (type == NPCID.Dryad && SummonWhipsnpcWorld.DownedMeteorBoss)
			 {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<CelestialMeteor>());
				nextSlot++;
			 }
	}

	public override void NPCLoot(NPC npc)
	{
		if(npc.type == NPCID.BrainofCthulhu)
		{
			// DROPS
			Item.NewItem(npc.getRect(), mod.ItemType("TheTongue"));
		}
		// MORE DROPS
		if (npc.boss && System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1)
		{
			Item.NewItem(npc.getRect(), mod.ItemType("WormWhip"));
		}
		
		if (Main.rand.Next(20) == 0 && Main.expertMode)
		{
			if(npc.type == NPCID.SolarCorite)
			Item.NewItem(npc.getRect(), mod.ItemType("MeteorShard"));
		}
		if(Main.rand.Next(100) < 10)
		{
			if(npc.type == NPCID.SolarCorite)
			Item.NewItem(npc.getRect(), mod.ItemType("MeteorShard"));
		}
		if (Main.rand.Next(5) == 0 && Main.expertMode)
		{
			if(npc.type == 185)
			Item.NewItem(npc.getRect(), mod.ItemType("Wool"), Main.rand.Next(1, 3));
		}
		if(Main.rand.Next(100) < 50)
		{
			if(npc.type == 185)
			Item.NewItem(npc.getRect(), mod.ItemType("Wool"), Main.rand.Next(1, 3));
		}
		if(Main.rand.Next(100) < 50)
		{
			if(npc.type == 250)
			Item.NewItem(npc.getRect(), mod.ItemType("CoreOfLightning"), 1);
		}
		if (Main.expertMode)
		{
			if(npc.type == 551)
			Item.NewItem(npc.getRect(), mod.ItemType("DragonHeart"), 1);
		}
		if (Main.expertMode)
		{
			if(npc.type == 439)
			Item.NewItem(npc.getRect(), mod.ItemType("MagicalTablet"), 1);
		}
	}
}
}