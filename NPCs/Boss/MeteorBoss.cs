using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;
using SummonWhips.Items.Others;
using SummonWhips.Projectiles;
//Main.PlaySound(SoundID.DD2_BetsyScream);

namespace SummonWhips.NPCs.Boss
{
    [AutoloadBossHead]

    public class MeteorBoss : ModNPC
    {
        //ai
        private int ai;
        private int attackTimer = 0;
        private bool fastSpeed = false;

        private bool stunned;
        private int stunnedTimer;

        //anim
        private int frame = 0;
        private double counting;
        

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corite Knight");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
        npc.width = 128;
        npc.height = 128;

        npc.boss = true;
        npc.aiStyle = -1; //74
        npc.npcSlots = 5f;

        npc.lifeMax = 83400;
        npc.damage = 100;
        npc.defense = 50;
        npc.knockBackResist =0f;

        npc.value = 1500000;

        npc.lavaImmune = true;
        npc.noTileCollide = true;
        npc.noGravity = true;

        npc.HitSound = SoundID.NPCHit3;
        npc.DeathSound = SoundID.DD2_BetsyScream;
        music = MusicID.TheTowers;

        bossBag = mod.ItemType("MeteorBossBag");

        } 

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale * 0.75);
            npc.damage = (int)(npc.damage * 1.2f);
        } 
        public override void AI()
        {
            if (npc.life < npc.lifeMax / 2)
        {
            npc.color = Color.Orange;
        }
            var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 170, 4f, 4f, 100, default, 1.5f);
			dust.noGravity = true;
			dust.velocity /= 2f;

            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;

            
            npc.netAlways = true;
            npc.spriteDirection = npc.direction + 2;

            //despawn
            if(npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if(npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }
            //stunned
            if(stunned)
            {
                npc.velocity.X = 0.0f;
                npc.velocity.Y = 0.0f;

                stunnedTimer++;

                if(stunnedTimer >= 100)
                {
                    stunned = false;
                    stunnedTimer = 0;
                }
            }
            if(npc.life >= npc.lifeMax * 0.05F) //if HP is more than 5% then check AI number
            {
                if(npc.life <= npc.lifeMax * 0.9F) //if HP is more than 5% then check AI number
                {
                if(npc.life >= npc.lifeMax * 0.5F) //laser attack 1st phase
                      {
                          Vector2 laserPos = npc.Center;
                          float laserAccuracy = 5f * (npc.life / npc.lifeMax);
                          Vector2 laserVel = target - laserPos + new Vector2(Main.rand.NextFloat(-laserAccuracy, laserAccuracy), Main.rand.NextFloat(-laserAccuracy, laserAccuracy));
                          laserVel.Normalize();
                          laserVel *= 10f;
                          if ((double)npc.ai[0] == 60.0)
                          {
                          Projectile.NewProjectile(laserPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laserPos.Y - (float)Main.rand.Next(-50, 40), laserVel.X, laserVel.Y, 100, 80, 1f);
                          }    
                          if ((double)npc.ai[0] == 115.0)
                          {
                          Projectile.NewProjectile(laserPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laserPos.Y - (float)Main.rand.Next(-50, 40), laserVel.X, laserVel.Y, 100, 80, 1f);
                          }       
                          if ((double)npc.ai[0] == 165.0)
                          {
                          Projectile.NewProjectile(laserPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laserPos.Y - (float)Main.rand.Next(-50, 40), laserVel.X, laserVel.Y, 100, 80, 1f);
                          }
                          if ((double)npc.ai[0] == 210.0)
                          {
                          Projectile.NewProjectile(laserPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laserPos.Y - (float)Main.rand.Next(-50, 40), laserVel.X, laserVel.Y, 100, 80, 1f);
                          }
                          if ((double)npc.ai[0] == 250.0)
                          {
                          Projectile.NewProjectile(laserPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laserPos.Y - (float)Main.rand.Next(-50, 40), laserVel.X, laserVel.Y, 100, 80, 1f);
                          }
                          if ((double)npc.ai[0] == 285.0)
                          {
                          Projectile.NewProjectile(laserPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laserPos.Y - (float)Main.rand.Next(-50, 40), laserVel.X, laserVel.Y, 100, 80, 1f);
                          }
                      }
                      else
                      { //laser attack 2nd phase
                          Vector2 laser2Pos = npc.Center;
                          float laser2Accuracy = 5f * (npc.life / npc.lifeMax);
                          Vector2 laser2Vel = target - laser2Pos + new Vector2(Main.rand.NextFloat(-laser2Accuracy, laser2Accuracy), Main.rand.NextFloat(-laser2Accuracy, laser2Accuracy));
                          laser2Vel.Normalize();
                          laser2Vel *= 10f;
                           if ((double)npc.ai[0] == 40.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 90.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 130.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 160.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 180.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 195.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 210.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 225.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 240.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 255.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 270.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                           if ((double)npc.ai[0] == 285.0)
                          {
                          Projectile.NewProjectile(laser2Pos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), laser2Pos.Y - (float)Main.rand.Next(-50, 40), laser2Vel.X, laser2Vel.Y, 100, 80, 1f);
                          }
                      }
                }
            }
            //stunned attack
            if(npc.life >= npc.lifeMax * 0.05F) //if HP is more than 5% then check AI number
            {
            if ((double)npc.ai[0] == 300.0)
            {        
                if(npc.life >= npc.lifeMax * 0.5F) //if boss is at 50% or above then do 1st phase attack
                      {
                          	if(Main.rand.Next(100) < 65) //first phase summon
		                {         
                          Main.NewText("Here's some of my minions for you to fight", (byte)180, (byte)240, (byte)160, false);
                          NPC.NewNPC((int)player.position.X, (int)player.position.Y +100, NPCID.SolarCorite);
                          NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarCorite);
                          NPC.NewNPC((int)player.position.X, (int)player.position.Y -80, NPCID.SolarCorite);
                          Main.PlaySound(SoundID.DD2_BetsyScream);
                        }
                        else //first phase 8-shot fireball
                        {         
                          Main.NewText("Fire at will!", (byte)180, (byte)240, (byte)160, false);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, 10f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, -10f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -3f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -3f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 10f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 10f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -10f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -10f, 686, npc.damage * 2, 5f);
                          Main.PlaySound(SoundID.DD2_BetsyScream);
                        }
                          
                      }
                      else if(Main.rand.Next(100) < 40) //2nd phase worm summon
                      {
                          Main.NewText("Here's a Crawltipede if you really think those are annoying", (byte)180, (byte)240, (byte)160, false);
                          NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarCrawltipedeHead);
                          Main.PlaySound(SoundID.DD2_BetsyScream);
                      }
                      else if(Main.rand.Next(100) < 40) //2nd phase guard summon
                      {
                          Main.NewText("Guards, ATTACK!", (byte)180, (byte)240, (byte)160, false);
                          NPC.NewNPC((int)npc.position.X, (int)npc.position.Y + 64, mod.NPCType("ArmoredCorite"));
                          NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 64, mod.NPCType("ArmoredCorite"));
                          Main.PlaySound(SoundID.DD2_BetsyScream);
                      }
                      else //2nd phase 12-shot fireball
                      {
                          Main.NewText("Fireballs, Fireballs everywhere", (byte)180, (byte)240, (byte)160, false);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, 10f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, -15f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -3f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -3f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 10f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 10f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -15f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -15f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 5f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 5f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -8f, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -8f, 686, npc.damage * 2, 5f);
                          NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 32, NPCID.SolarFlare);
                          NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarFlare);
                          NPC.NewNPC((int)npc.position.X, (int)npc.position.Y + 32, NPCID.SolarFlare);
                          Main.PlaySound(SoundID.DD2_BetsyScream);
                      }
            }
            }
            if(npc.life <= npc.lifeMax * 0.07F && npc.life >= npc.lifeMax * 0.05F)
                    {
                        player.AddBuff(197, 2 * 60);
                    }
           if(npc.life <= npc.lifeMax * 0.05F) //if HP is more than 5% then execute ultimate pattern
            {
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) > 900f) //anti cheese
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y +80, NPCID.DungeonGuardian);
                    player.AddBuff(149, 60 * 60);
                    Main.NewText("No cheesing!", (byte)180, (byte)240, (byte)160, false);
                }
                if ((double)npc.ai[0] == 10.0)
                {
                    npc.color = Color.Red;
                    player.AddBuff(149, 2 * 60);
                    player.AddBuff(8, 5 * 60);
                    player.AddBuff(59, 8 * 60);
                    player.AddBuff(ModContent.BuffType<Buffs.Resistance>(), 18 * 60);
                    player.QuickSpawnItem(58);
                    player.QuickSpawnItem(3454);
                    Projectile.NewProjectile(npc.position.X + 720, npc.position.Y, 0f, 0f, ModContent.ProjectileType<BossWall>(), 5000, 5f);
                    Projectile.NewProjectile(npc.position.X - 720, npc.position.Y, 0f, 0f, ModContent.ProjectileType<BossWall>(), 5000, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y + 720, 0f, 0f, ModContent.ProjectileType<BossCeiling>(), 5000, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y - 720, 0f, 0f, ModContent.ProjectileType<BossCeiling>(), 5000, 5f);
                }
                if ((double)npc.ai[0] == 20.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 30.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 40.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 50.0)
                {
                    frame = 0;
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    npc.life = 1;
                    player.QuickSpawnItem(58);
                    player.QuickSpawnItem(3454);
                    Main.NewText("What if you,", (byte)180, (byte)240, (byte)160, false);
                }
                if ((double)npc.ai[0] == 60.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 70.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 80.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 90.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 100.0)
                {
                    player.QuickSpawnItem(58);
                    player.QuickSpawnItem(3454);
                    Main.NewText("Wanted to beat me,", (byte)180, (byte)240, (byte)160, false);
                }
                if ((double)npc.ai[0] == 110.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 120.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 130.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 140.0)
                {
                    player.QuickSpawnItem(58);
                }
                if ((double)npc.ai[0] == 150.0)
                {   
                    player.QuickSpawnItem(58);
                    player.QuickSpawnItem(3454);
                    Main.NewText("But i said,", (byte)180, (byte)240, (byte)160, false);
                }
                    if ((double)npc.ai[0] == 200.0)
                {
                    player.QuickSpawnItem(58);
                    player.QuickSpawnItem(3454);
                    Main.NewText("FIREBALL SPAM!", (byte)180, (byte)240, (byte)160, false);
                }
                if ((double)npc.ai[0] == 250.0)
                {
                    frame = 1;
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, -10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -10f, 686, npc.damage * 2, 5f);
                }
                if ((double)npc.ai[0] == 300.0)
                {
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarCrawltipedeHead);
                }
                if ((double)npc.ai[0] == 350.0)
                {
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, -10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -10f, 686, npc.damage * 2, 5f);   
                }
                if ((double)npc.ai[0] == 370.0)
                {   Main.PlaySound(SoundID.DD2_BetsyScream);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarFlare);
                }
                if ((double)npc.ai[0] == 385.0)
                {    
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarFlare);
                }
                if ((double)npc.ai[0] == 400.0)
                {    
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarFlare);
                }
                if ((double)npc.ai[0] == 415.0)
                {    
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarFlare);
                }
                if ((double)npc.ai[0] == 430.0)
                {    
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarFlare);
                }
                if ((double)npc.ai[0] == 450.0)
                {   Main.PlaySound(SoundID.DD2_BetsyScream);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, -10f, 686, npc.damage * 2, 5f);     
                }
                if ((double)npc.ai[0] == 470.0)
                {    
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -10f, 686, npc.damage * 2, 5f);    
                }
                if ((double)npc.ai[0] == 490.0)
                {    
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -3f, 686, npc.damage * 2, 5f);
                }
                if ((double)npc.ai[0] == 510.0)
                {    
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -10f, 686, npc.damage * 2, 5f); 
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 10f, 686, npc.damage * 2, 5f);    
                }
                if ((double)npc.ai[0] == 530.0)
                {    
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, -10f, 686, npc.damage * 2, 5f);     
                }
                if ((double)npc.ai[0] == 550.0)
                {    
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -10f, 686, npc.damage * 2, 5f);    
                }
                if ((double)npc.ai[0] == 570.0)
                {    
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -3f, 686, npc.damage * 2, 5f);
                }
                if ((double)npc.ai[0] == 590.0)
                {    
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -10f, 686, npc.damage * 2, 5f); 
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 10f, 686, npc.damage * 2, 5f);    
                }
                if ((double)npc.ai[0] == 615.0)
                {   
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y + 64, mod.NPCType("ArmoredCorite"));
                }
                if ((double)npc.ai[0] == 650.0)
                {   
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, -15f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -15f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -15f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -8f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -8f, 686, npc.damage * 2, 5f);
                }
                if ((double)npc.ai[0] == 700.0)
                {   
                    Main.PlaySound(SoundID.DD2_BetsyScream); 
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y +80, NPCID.SolarCorite);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y +32, NPCID.SolarCorite);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y -64, NPCID.SolarCorite);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y +96, NPCID.SolarCorite);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y -80, NPCID.SolarCorite);
                }
                if ((double)npc.ai[0] == 750.0)
                {  
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 1f, -15f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -3f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 10f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -15f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -15f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, 5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, 5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 10f, -8f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -10f, -8f, 686, npc.damage * 2, 5f);
                }
                if ((double)npc.ai[0] == 800.0)
                {  
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y + 64, mod.NPCType("ArmoredCorite"));
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.SolarCrawltipedeHead);
                }
                if ((double)npc.ai[0] == 900.0)
                {  
                    Main.PlaySound(SoundID.DD2_BetsyScream);
                    Projectile.NewProjectile(npc.position.X + 48, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X + 208, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X - 112, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X + 368, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X - 272, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X + 528, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X - 432, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X + 688, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                    Projectile.NewProjectile(npc.position.X - 592, npc.position.Y - 128, 0f, -5f, 686, npc.damage * 2, 5f);
                }
                if ((double)npc.ai[0] == 1100.0)
                {  
                    Main.NewText("You may have beaten me,", (byte)180, (byte)240, (byte)160, false);
                }
                if ((double)npc.ai[0] == 1250.0)
                {  
                    Main.NewText("But there are more things to do after i have been defeated.", (byte)180, (byte)240, (byte)160, false);
                }
                if ((double)npc.ai[0] == 1400.0)
                {  
                    Main.NewText("Hope you will fight me again for more loot!", (byte)180, (byte)240, (byte)160, false);
                }
                if ((double)npc.ai[0] == 1550.0)
                {  
                    Main.NewText("But now, i have to go. See you again soon!", (byte)180, (byte)240, (byte)160, false);
                }
                if ((double)npc.ai[0] == 1650.0)
                {  
                    npc.defense = 0;
                    npc.dontTakeDamage = false;
                }

            }
            ai++;
            //0-300 = normal
            //300-350 = stunned
            //350-800 = fast
            //when it reaches 800, goes back to normal
            //movement
            npc.ai[0] = (float)ai * 1f;
            if(npc.life >= npc.lifeMax * 0.05F) //if HP is more than 5% then do normal AI
            {
            int distance = (int)Vector2.Distance(target, npc.Center);
            if((double)npc.ai[0] < 300) //moving
            {
                frame = 0;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            } else if((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 350.0) //stunned
            {
                stunned = true;
                frame = 1;
                npc.defense = 9999;
                npc.damage = 300;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            } 
            else if((double)npc.ai[0] >= 350.0) 
            {
                frame = 1;
                stunned = false;
                npc.damage = (int)(100 * 1.5f); 
                npc.defense = 50;
                if (!fastSpeed)
                {
                    fastSpeed = true;

                }
                else
                {
                   if ((double)npc.ai[0] % 50 == 0)
                   {
                       float speed = 14f;
                       Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                       float x = player.position.X + (float)(player.width / 2) - vector.X;
                       float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                       float distance2 = (float)Math.Sqrt(x * x + y * y);
                       float factor = speed / distance2;
                       npc.velocity.X = x * factor;
                       npc.velocity.Y = y * factor;
                   }
                }
                npc.netUpdate = true;
            }
            //ATTACK
            if((double)npc.ai[0] % (Main.expertMode ? 100 : 150) == 0 && !stunned && !fastSpeed)
            {
                attackTimer++;
              if (attackTimer <=2)
              {
                  frame = 2;
                  npc.velocity.X = 0f;
                  npc.velocity.Y = 0f;
                  Vector2 shootPos = npc.Center;
                  float accuracy = 5f * (npc.life / npc.lifeMax);
                  Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                  shootVel.Normalize();
                    shootVel *= 14.5f;
                  for(int i = 0; i < (Main.expertMode ? 5 : 3); i++)
                  {
                      if(npc.life >= npc.lifeMax * 0.5F) 
                      {
                          //1st phase = 3 fireballs
                          Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, 686, npc.damage * 2, 5f);

                      } else
                      {
                          //2nd phase = 6 fireballs
                          Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-150, 140), shootVel.X, shootVel.Y, 686, npc.damage * 2, 5f);
                          Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-40, 30), shootVel.X, shootVel.Y, 686, npc.damage * 2, 5f);

                      }
                  }
              }
              else
              {
                  attackTimer = 0;
              }
            }
            if ((double)npc.ai[0] >= 800.0)
            {
                ai = 0;
                npc.alpha = 0;
                fastSpeed = false;
            }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)                
        {
            target.AddBuff(36, 5 * 60);
            target.AddBuff(67, 5 * 60);
            target.AddBuff(196, 5 * 60);
        }

        public override void FindFrame(int frameHeight)
        {
            if(frame == 0)
            {
                counting += 1.0;
                if(counting < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if(counting < 16.0)
                {
                  npc.frame.Y = 0;
                }
                else if (counting < 24.0)
                {
                  npc.frame.Y = 0;
                }
                else if (counting < 32.0)
                {
                  npc.frame.Y = 0;
                }
                else 
                {
                    counting = 0.0;
                }
            }
            else if(frame == 1)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = frameHeight;
            }
        }
        private void MoveTowards(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var move = playerTarget - npc.Center;
            float length = move.Length();
            if(length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if(length > speed)
            {
                move *= speed / length;
            }
            npc.velocity = move;
        }
        public override void NPCLoot()
        {
            SummonWhipsnpcWorld.DownedMeteorBoss = true;
            if(Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Others.MeteorCore>());
                
                var dropChooser = new WeightedRandom<int>();
                dropChooser.Add(ModContent.ItemType<Items.Others.MeteorInABottle>()); //meteor pet
                dropChooser.Add(ModContent.ItemType<Items.Others.MeteorEmblem>()); //meteor accessory
                dropChooser.Add(ModContent.ItemType<Items.Others.MeteorSquarePlane>()); // sqaure plane boomerang
                dropChooser.Add(ModContent.ItemType<Items.Others.MeteorInferno>()); //meteor inferno
                int choice = dropChooser;
                Item.NewItem(npc.getRect(), choice);

                if(Main.rand.Next(100) < 50)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width,npc.height, mod.ItemType("MeteorShard"), Main.rand.Next(1, 3));
                }
                if (Main.rand.Next(10) == 0)
	            Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Others.MeteorBossTrophy>());
                if (Main.rand.Next(10) == 0)
	            Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Others.FireballTrophy>());

            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if(npc.life <= npc.lifeMax * 0.05F) //if boss is at 5% or less then start ultimate AI
                    {
                        npc.defense = 9999;
                        npc.dontTakeDamage = true; 
                        ai = 0;
                        npc.velocity.X = 0.0f;
                        npc.velocity.Y = 0.0f;
                    }
        }
    }
}