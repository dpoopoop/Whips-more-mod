using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using SummonWhips.Projectiles.Minions;

namespace SummonWhips.Items.Others
{
	[AutoloadEquip(EquipType.Head)]
	public class LightningHeadpiece : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases summon damage by 8%"
			+ "\nIncreases max number of minions by 1");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 24;
			item.value = Item.sellPrice(silver: 600);
			item.rare = ItemRarityID.Pink;
			item.defense = 8;
		}
		public override void UpdateEquip(Player player) {
			player.minionDamage *= 1.08f;
			player.maxMinions += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<LightningSuit>() && legs.type == ModContent.ItemType<LightningLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.GetModPlayer<WhipPlayer>().lightning = true;
			player.setBonus = "Increases max number of sentries by 1"
			+ "\nElectric orb above your head protects you";
			player.maxTurrets += 1;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<ElectricOrb>()] <= 0)
			{
				player.AddBuff(ModContent.BuffType<Buffs.ElectricOrb>(), 2);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("ElectricOrb"), 0, 0f, Main.myPlayer, 0f, 0f); 
			}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CoreOfLightning>(), 1);
			recipe.AddIngredient(1225, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
