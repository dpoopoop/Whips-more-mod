using SummonWhips.NPCs.Boss;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SummonWhips.Items;
using SummonWhips.Items.Others;

namespace SummonWhips.Items
{
	public class MeteorBossBag : ModItem
	{
		public override int BossBagNPC => mod.NPCType("MeteorBoss");

		//public override int BossBagNPC
		//{
			//get
			//{
				//return mod.NPCType("MeteorBoss");
			//}
		//}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteor Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 40;
			item.height = 40;
			item.rare = -12;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) 
		{
			player.QuickSpawnItem(ItemID.GoldCoin, 150);
			player.QuickSpawnItem(ItemID.SuperHealingPotion, Main.rand.Next(5, 10));
			player.QuickSpawnItem(ItemID.SuperManaPotion, Main.rand.Next(5, 10));
			player.TryGettingDevArmor();
			player.TryGettingDevArmor();
			int choice = Main.rand.Next(3);
			if (choice == 0) {
				player.QuickSpawnItem(ModContent.ItemType<MeteorInABottle>()); //meteor pet
			}
			else if (choice == 1) {
				player.QuickSpawnItem(ModContent.ItemType<MeteorEmblem>()); //meteor accesory
				}
			else if (choice == 2) {
				player.QuickSpawnItem(ModContent.ItemType<MeteorSquarePlane>());  //square plane boomerang
			}
			else if (choice == 3) {
				player.QuickSpawnItem(ModContent.ItemType<MeteorInferno>()); //meteor inferno
			}

			player.QuickSpawnItem(ModContent.ItemType<MeteorCore>());
			player.QuickSpawnItem(ModContent.ItemType<MeteorWings>());

			if(Main.rand.Next(2) < 1)
			{
				player.QuickSpawnItem(ItemID.FragmentSolar, Main.rand.Next(10, 30));
			}
			if(Main.rand.Next(2) < 1)
			{
				player.QuickSpawnItem(ModContent.ItemType<MeteorShard>());
			}
			if(Main.rand.Next(100) < 10)
			{
				player.QuickSpawnItem(ModContent.ItemType<FireballTrophy>());
			}
			if(Main.rand.Next(100) < 10)
			{
				player.QuickSpawnItem(ModContent.ItemType<MeteorBossTrophy>());
			}
		}

	}
}