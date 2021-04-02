using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ModLoader;
using System;

namespace SummonWhips.Items.Neutral
{
	public class PhotonSniper : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Converts bullets into burning bullets.
'Turn up the heat!'");
		}

		public override void SetDefaults() {
			item.damage = 172; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 73; // hitbox width of the item
			item.height = 32; // hitbox height of the item
			item.useTime = 36; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 36; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 1200); // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Lime; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item36; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10; 
			item.shootSpeed = 25f; // the speed of the projectile (measured in pixels per frame)
			item.ranged = true;
			item.crit = 25;
			item.useAmmo = AmmoID.Bullet;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) {
				type = ModContent.ProjectileType<PhotonBullet>();
				item.damage = 200; }
				else
				{
				item.damage = 172; 
				}
			return true; 
		}
	}
}