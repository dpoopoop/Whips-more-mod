using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Items.Others;

namespace SummonWhips.Tiles
{
	public class OreoCreamOre : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; 
			Main.tileValue[Type] = 855; 
			Main.tileShine2[Type] = true; 
			Main.tileShine[Type] = 950; 
			Main.tileMergeDirt[Type] = false;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Oreo Cream Ore");
			AddMapEntry(new Color(200, 200, 200), name);

			dustType = 82;
			drop = ModContent.ItemType<Items.Others.OreoCreamOre>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 4f;
			minPick = 225;
		}
	}
}