using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using SummonWhips.Items.Others;

namespace SummonWhips.Items.Others
{
	public class CelestialMeteor : ModItem
	{
       public override void SetStaticDefaults()
	   {
		   DisplayName.SetDefault("Celestial Meteor");
		   Tooltip.SetDefault(@"'Really hot to the touch, feels like there is a huge amount of energy packed into this meteor'.
Summons the Corite Knight");
	   }
	   public override void SetDefaults()
	   {
		   item.width = 26;
		   item.height = 26;
		   item.rare = 10;
		   item.maxStack = 999;
		   item.useAnimation = 45;
		   item.useTime = 45;
		   item.useStyle = 4;
		   item.value = 1000000;
		   item.consumable = true;
	   }
	   public override bool CanUseItem(Player player)
	   {
		   return !NPC.AnyNPCs(mod.NPCType("MeteorBoss"));
	   }
	   public override bool UseItem(Player player)
	   {
		   Main.PlaySound(SoundID.DD2_BetsyScream);
		   if(Main.netMode !=1)
		   {
			   NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("MeteorBoss"));
		   }
		   return true;
	   }
	public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MeteorShard>(), 3);
			recipe.AddIngredient(ItemID.FragmentSolar, 30);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}