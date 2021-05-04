using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Buffs;

namespace ExpandedWeapons.Items.Summon
{
	public class MiniPlantera : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots plantera seeds that have deadly poison");
		}

		public override void SetDefaults() {
			item.damage = 12; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 56; // hitbox width of the item
			item.height = 24; // hitbox height of the item
			item.useTime = 25; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 25; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 800);
			item.rare = ItemRarityID.Yellow; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item63; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<MiniPlanteraProj>();
			item.shootSpeed = 22f; // the speed of the projectile (measured in pixels per frame)
			item.mana = 9;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 46f; //This gets the direction of the flame projectile, makes its length to 1 by normalizing it. It then multiplies it by 54 (the item width) to get the position of the tip of the flamethrower.
			if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
			{
				position += muzzleOffset;
			}
			return true;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.AddIngredient(ItemID.PiranhaGun, 1);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}