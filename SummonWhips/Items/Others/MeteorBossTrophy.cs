using Terraria.ModLoader;
using Terraria.ID;

namespace SummonWhips.Items.Others
{
	public class MeteorBossTrophy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteor Trophy");
			Tooltip.SetDefault("'This trophy still has some energy packed into it'");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 50000;
			item.rare = ItemRarityID.Purple;
			item.createTile = ModContent.TileType<Tiles.MeteorTrophy>();
			item.placeStyle = 0;
		}
	}
}