using SummonWhips.Projectiles.Minions;
using SummonWhips.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others
{
	public class CoriteStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a corite to fight for you.
'They were bad but now they are good'");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 110;
			item.summon = true;
			item.mana = 20;
			item.width = 64;
			item.height = 64;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 1500000; 
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.DD2_BetsyScream;
			item.shoot = ModContent.ProjectileType<CoriteSmall>();
			item.buffType = ModContent.BuffType<Buffs.Corite>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.MeteoriteBar, 50);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddIngredient(ModContent.ItemType<MeteorCore>(), 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}