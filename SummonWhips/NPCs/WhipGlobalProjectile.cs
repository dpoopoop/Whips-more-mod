using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SummonWhips.Items.Others;
using SummonWhips.NPCs;
using SummonWhips.Buffs;
using SummonWhips.Projectiles;
using SummonWhips.Projectiles.Minions;

namespace SummonWhips.NPCs
{
	public class WhipGlobalProjectile : GlobalProjectile
    {
    public override bool InstancePerEntity => true;

	public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
				if(projectile.type == ModContent.ProjectileType<Magic4>())
				{
					//do nothing
				}
				else if(projectile.type == ModContent.ProjectileType<MagicSpray>())
				{
					//do nothing
				}
				else if(projectile.type == ModContent.ProjectileType<MagicShadow>())
				{
					//do nothing
				}
				else if(projectile.type == ModContent.ProjectileType<MagicFireball>())
				{
					//do nothing
				}
				else
				{
            if (crit == true && player.GetModPlayer<WhipPlayer>().randomDebuff == true)
            {
               switch (Main.rand.Next(4))
				{
				case 0:
					Projectile.NewProjectile(player.position.X, player.position.Y, MathHelper.Lerp(-2f, 2f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-2f, 2f, (float)Main.rand.NextDouble()), ModContent.ProjectileType<MagicSpray>(), damage / 3, 1f, player.whoAmI);
					break;
				case 1:
					Projectile.NewProjectile(player.position.X, player.position.Y, MathHelper.Lerp(-2f, 2f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-2f, 2f, (float)Main.rand.NextDouble()), ModContent.ProjectileType<Magic4>(), damage / 3, 1f, player.whoAmI);
					break;
				case 2:
					Projectile.NewProjectile(player.position.X, player.position.Y, MathHelper.Lerp(-2f, 2f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-2f, 2f, (float)Main.rand.NextDouble()), ModContent.ProjectileType<MagicShadow>(), damage / 3, 1f, player.whoAmI);
					break;
				default:
					Projectile.NewProjectile(player.position.X, player.position.Y, MathHelper.Lerp(-2f, 2f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-2f, 2f, (float)Main.rand.NextDouble()), ModContent.ProjectileType<MagicFireball>(), damage / 3, 1f, player.whoAmI);
					break;
				}
				}
            }
      }
	}
}