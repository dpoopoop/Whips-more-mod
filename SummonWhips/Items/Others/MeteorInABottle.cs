using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Projectiles.Minions;
using SummonWhips.Buffs;

namespace SummonWhips.Items.Others
{
	public class MeteorInABottle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor in a Bottle");
			Tooltip.SetDefault("Summons a flaming meteor");
		}
	

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("FlamingMeteor");
			item.buffType = mod.BuffType("Meteor");
			item.value = Item.sellPrice(silver: 5000);
			item.rare = ItemRarityID.Purple;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}