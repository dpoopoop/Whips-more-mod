using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using SummonWhips.Items.Others;
 
namespace SummonWhips.Tiles
{
    public class BossFireballTrophy : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 42;
            TileObjectData.addTile(Type);           
            disableSmartCursor = true;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY) 
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Others.FireballTrophy>());
        }
 
    }
}

		