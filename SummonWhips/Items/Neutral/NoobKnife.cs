using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;

namespace SummonWhips.Items.Neutral
{
	public class NoobKnife : NeutralClass
	{
		public override void SafeSetDefaults() 
		{
			item.shootSpeed = 15f;
			item.damage = 30;
			item.knockBack = 4f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 30;
			item.useTime = 30;
			item.width = 16;
			item.height = 32;
			item.rare = ItemRarityID.Green;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 100);
			item.shoot = ModContent.ProjectileType<SimKnife>();
		}
	}
}