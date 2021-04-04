using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Neutral
{
	public class HyperlaserBlaster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'IMMA FIRIN' MAH LAZORS!'");
		}

		public override void SetDefaults() {
			item.damage = 125;
			item.magic = true;
			item.mana = 10;
			item.width = 32;
			item.height = 24;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(silver: 1200);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item91;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Hyperlaser>();
			item.shootSpeed = 20f;
		}
		
	}
}