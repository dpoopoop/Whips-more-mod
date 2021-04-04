using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Neutral
{
	public class SolarFlareSpell : NeutralClass
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots a slow moving ball that fires lasers at nearby enemies");
		}

		public override void SafeSetDefaults() {
			item.damage = 96;
			item.mana = 20;
			item.width = 32;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 1600);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item82;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<SolarBall>();
			item.shootSpeed = 1.5f;
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
        }
	}
}
	