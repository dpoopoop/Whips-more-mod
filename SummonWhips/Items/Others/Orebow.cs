using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using System;

namespace SummonWhips.Items.Others
{
	public class Orebow : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ore-bow");
			Tooltip.SetDefault(@"Has a chance to shoot a bouncing oreo cookie.
30% chance to not consume arrows.
'Here, have a cookie.'");
		}

		public override void SetDefaults() {
			item.damage = 200; 
			item.ranged = true; 
			item.width = 64; 
			item.height = 64; 
			item.useTime = 15; 
			item.useAnimation = 15; 
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.knockBack = 4; 
			item.value = 2700000;
			item.rare = ItemRarityID.Purple; 
			item.UseSound = SoundID.DD2_BallistaTowerShot.WithVolume(.6f); 
			item.autoReuse = true; 
			item.shoot = 1; //1 for arrow
			item.shootSpeed = 25f; 
			item.useAmmo = AmmoID.Arrow; 
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .30f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(Main.rand.Next(100) < 20)
		    {
				Projectile.NewProjectile(position.X, position.Y, speedX / 5, speedY, ModContent.ProjectileType<Cookie>(), damage * 2, knockBack * 2, player.whoAmI);
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/oreopew").WithVolume(1.2f).WithPitchVariance(.5f));
			}
		int projectileCount = 1;
            float startRadius = 15f; 
            float spread = (float)Math.PI / 18f; 
            Vector2 direction = Vector2.Normalize(new Vector2(speedX, speedY));
            direction *= startRadius;
            for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread - 5);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }
            for (int i = 0; i < projectileCount; i++)
            {
                float angleStep = (float)(i - (projectileCount - 1)) / 2f;
                Vector2 firePosition = direction.RotatedBy(angleStep * spread + 5);
                Projectile.NewProjectile(position.X + firePosition.X, position.Y + firePosition.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }
			return false;
	}
	public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OreoBar>(), 18);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

