using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;

namespace SummonWhips.Items.Neutral
{
	public class CodyStriker : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots a cool looking wave
'Forged by someone who likes baguettes'");
		}
		public override void SetDefaults() {
			item.damage = 20;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 16;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.5f;
			item.value = Item.sellPrice(silver: 400);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<CodyProj>();
			item.shootSpeed = 8f;
		}

	}
}