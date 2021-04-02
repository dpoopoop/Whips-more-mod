using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles;

namespace SummonWhips.Items.Others
{
	public class MeteorWrath : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Showers meteors from the sky.
'Star Wrath but stronger'");
		}

		public override void SetDefaults() {
			item.damage = 225; 
			item.melee = true; 
			item.width = 64; 
			item.height = 64; 
			item.useTime = 15; 
			item.useAnimation = 15;
			item.knockBack = 6.5f; 
			item.value = 1500000;
			item.rare = ItemRarityID.Purple; 
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true; 
			item.crit = 6; 
			item.shoot = ModContent.ProjectileType<WrathMeteor>();
			item.shootSpeed = 18f;
			item.useStyle = ItemUseStyleID.SwingThrow;
		}

            public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.MeteoriteBar, 50);
			recipe.AddIngredient(ItemID.FragmentSolar, 20);
			recipe.AddIngredient(ModContent.ItemType<MeteorCore>(), 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(3)) {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 127);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
		{
			target.AddBuff(69, 3 * 60);
			target.AddBuff(189, 10 * 60);
			target.AddBuff(204, 3 * 60);
			target.AddBuff(24, 10 * 60);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 3; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}
	}
}