using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;

namespace SummonWhips.Items.Neutral
{
	public class BaguetteThief : NeutralClass
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'The thief of lives'");
		}
		public override void SafeSetDefaults() 
		{
			item.shootSpeed = 15f;
			item.damage = 30;
			item.knockBack = 4f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 28;
			item.useTime = 28;
			item.width = 16;
			item.height = 32;
			item.rare = ItemRarityID.Green;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 400);
			item.shoot = ModContent.ProjectileType<Baguette>();
		}
	}
}