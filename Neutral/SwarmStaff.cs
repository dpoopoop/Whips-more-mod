using SummonWhips.Projectiles.Minions;
using SummonWhips.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Neutral
{
	public class SwarmStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a swarm drone to fight for you.
'Quantity over quality for this weapon!'");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 16;
			item.summon = true;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 24;
			item.useAnimation = 24;
			item.autoReuse = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = Item.sellPrice(silver: 1200);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item44;
			item.shoot = ModContent.ProjectileType<SwarmDrone>();
			item.buffType = ModContent.BuffType<Buffs.Drone>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
	}
}