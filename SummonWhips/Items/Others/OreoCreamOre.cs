using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class OreoCreamOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 59;
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.OreoCreamOre>();
			item.width = 16;
			item.height = 16;
			item.value = 30000;
		}
	}
}