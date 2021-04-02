using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Threading;
using System.Collections.Generic;
using Terraria.ModLoader.IO;
using System.IO;
using Terraria.DataStructures;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SummonWhips.NPCs;

namespace SummonWhips.NPCs
{
	public class SummonWhipsnpcWorld : ModWorld
    {
		public static bool DownedMeteorBoss = false;

		public override void Initialize()
		{
			DownedMeteorBoss = false;
			Noob.spawnTime = double.MaxValue;
		}
		public override TagCompound Save()
		{
			var Downed = new List<string>();
			if (DownedMeteorBoss) 
			{
			Downed.Add("meteorBoss");
			}

			return new TagCompound
			{
				["traveler"] = Noob.Save(),
				["Version"] = 0,
				["Downed"] = Downed
						
			};
		}
		public override void Load(TagCompound tag)
		{
			var Downed = tag.GetList<string>("Downed");
			DownedMeteorBoss = Downed.Contains("meteorBoss");
			Noob.Load(tag.GetCompound("traveler"));
		}
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if(loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				DownedMeteorBoss = flags[0];
			}
		}
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags [0] = DownedMeteorBoss;

			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			DownedMeteorBoss = flags[0];
		}
		public override void PreUpdate() {
			//Update everything about spawning the traveling merchant from the methods we have in the Traveling Merchant's class
			Noob.UpdateTravelingMerchant();
		}
	}
}
	    