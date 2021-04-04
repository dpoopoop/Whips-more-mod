using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items
{
	public class SuspiciousWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Suspicious Whip");
			Tooltip.SetDefault(@"Increases damage of your minions by 10% while using this weapon.
'I don't know but this whip looks pretty sus to me'");
		}
		public override void SetDefaults() {
            item.width = 40;
            item.height = 40;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 18; //Whip animation
            item.useTime = 18; //Whip time
            item.reuseDelay = 8;
            item.shootSpeed = 36f; //Range
            item.knockBack = 8f;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Cyan;
            item.shoot = ModContent.ProjectileType<SuspiciousWhipProj>();
            item.value = Item.sellPrice(silver: 1600);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;
            item.summon = true;
            item.damage = 275;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            // How far out the inaccuracy of the shot chain can be.
            float radius = 60f;
            player.AddBuff(ModContent.BuffType<Buffs.SummonTag>(), 75);
            // Sets ai[1] to the following value to determine the firing direction.
            // The smaller the value of NextFloat(), the more accurate the shot will be. The larger, the less accurate. This changes depending on your radius.
            // NextBool().ToDirectionInt() will have a 50% chance to make it negative instead of positive.
            // The Solar Eruption uses this calculation: Main.rand.NextFloat(0f, 0.5f) * Main.rand.NextBool().ToDirectionInt() * MathHelper.ToRadians(45f);
            float direction = Main.rand.NextFloat(0.25f, 1f) * Main.rand.NextBool().ToDirectionInt() * MathHelper.ToRadians(radius);
            Projectile projectile = Projectile.NewProjectileDirect(player.RotatedRelativePoint(player.MountedCenter), new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI, 0f, direction);
            // Extra logic for the chain to adjust to item stats, unlike the Solar Eruption.
            if (projectile.modProjectile is SuspiciousWhipProj modItem)
            {
                modItem.firingSpeed = item.shootSpeed * 2f;
                modItem.firingAnimation = item.useAnimation;
                modItem.firingTime = item.useTime;
            }
            return false;
        }

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 100);
			recipe.AddIngredient(ItemID.AntiGravityHook, 1);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
