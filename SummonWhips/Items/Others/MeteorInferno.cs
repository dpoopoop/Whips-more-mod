using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SummonWhips.Items.Others
{
	public class MeteorInferno : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots 3 fireballs that melts enemy defense.
'Great for supporting any class, not just for mages'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 200;
			item.magic = true;
			item.mana = 18;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = Item.sellPrice(silver: 5000);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.DD2_BetsyFireballShot.WithVolume(.5f);
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<InfernoBall>();
			item.shootSpeed = 50f;
		}
	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
	{
			player.AddBuff(ModContent.BuffType<Buffs.ArmorMelt>(), 10 * 60);
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 2, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		
	}
}
}