using Terraria.ModLoader;
using Terraria.ID;

namespace SummonWhips.Items.Others
{
	public class FireballTrophy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fireball Trophy");
			Tooltip.SetDefault("'How many times have you been killed by that fireball attack?'");
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
			item.value = 1000000;
			item.rare = ItemRarityID.Purple;
			item.createTile = ModContent.TileType<Tiles.BossFireballTrophy>();
			item.placeStyle = 0;
		}
	}
}