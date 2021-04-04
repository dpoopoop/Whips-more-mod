using SummonWhips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Neutral
{
	public class GoldenWand : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Left click to shoot a magic bolt, and right click to shoot a fireball.");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 28;
			item.magic = true;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = Item.sellPrice(silver: 400);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item29;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<GoldenBolt>();
			item.shootSpeed = 20f;
		}
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				item.useStyle = ItemUseStyleID.HoldingOut; //Fireball
				item.damage = 70;
				item.useAnimation = 35;
				item.useTime = 35;
				item.knockBack = 6;
				item.shootSpeed = 10f;
				item.UseSound = SoundID.Item20;
				item.shoot = 668;
			}
			else {
				item.useStyle = ItemUseStyleID.HoldingOut; //Bolt
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 28;
				item.useTime = 20;
				item.knockBack = 4;
				item.shootSpeed = 20f;
				item.UseSound = SoundID.Item29;
				item.shoot = ModContent.ProjectileType<GoldenBolt>();
			}
			return base.CanUseItem(player);
		
			}
		}
}