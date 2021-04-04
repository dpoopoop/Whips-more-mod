using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;

namespace SummonWhips.Items.Neutral
{
	public class HotDog : NeutralClass
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'These hotdogs are so hot, its burning!'");
		}
		public override void SafeSetDefaults() 
		{
			item.shootSpeed = 15f;
			item.damage = 60;
			item.knockBack = 4f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 16;
			item.height = 32;
			item.rare = ItemRarityID.Pink;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 800);
			item.shoot = ModContent.ProjectileType<Hotdog>();
		}
	}
}