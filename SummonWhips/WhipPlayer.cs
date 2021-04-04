using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SummonWhips.Projectiles;
using Terraria.Localization;

namespace SummonWhips
{
	// This is the ModPlayer class. Make note of the classname, which is whipplayer, since we will be using this in the accessory item below.
	public class WhipPlayer : ModPlayer
	{
		// Here we declare the meteorrain variable which will represent whether this player has the effect or not.
		public bool MeteorRain;
		private const int saveVersion = 0;
        public bool memePet = false;
		public bool lightning;
		public bool ichorItem;
		public bool randomDebuff;
		public bool coriteArcri;

		// ResetEffects is used to reset effects back to their default value. Terraria resets all effects every frame back to defaults so we will follow this design. (You might think to set a variable when an item is equipped and unassign the value when the item in unequipped, but Terraria is not designed that way.)
		public override void ResetEffects() {
			MeteorRain = false;
            memePet = false;
			lightning = false;
			ichorItem = false;
			randomDebuff = false;
			coriteArcri = false;
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) 
		{
			if (ichorItem && !proj.noEnchantments) 
			{
				target.AddBuff(203, 60 * 3, false);
			}	
		}

		// Here we use a "hook" to actually let our meteor rain take effect. This hook is called anytime a player owned projectile hits an enemy. 
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (MeteorRain == true)
            {
                float spread = 45f * 0.0174f;
                double deltaAngle = spread / 8f;
                double offsetAngle;
                int i;
                for (i = 0; i < 4; i++)
                {
                    offsetAngle = (deltaAngle * (i + i * i) / 2f) + 32f * i;
                    Terraria.Projectile.NewProjectile(player.position.X,player.position.Y - Main.rand.Next(400, 500), (float)Main.rand.Next(-10, 10), (float)(Math.Cos(offsetAngle) + 20),mod.ProjectileType("WrathMeteor"), 100, 1, player.whoAmI, 0);
                    Terraria.Projectile.NewProjectile(player.position.X, player.position.Y - Main.rand.Next(400, 500), (float)Main.rand.Next(-10, 10), (float)(-Math.Cos(offsetAngle) + 20), mod.ProjectileType("WrathMeteor"), 100, 1, player.whoAmI, 0);
                }
            }
        }
	
		// As a recap. Make a class variable, reset that variable in ResetEffects, and use that variable in the logic of whatever hooks you use.
	}
	// Note that since this namespace is nested within the outer namespace of "summonwhips", the full namespace is summonwhips.Items.others. This is important because textures are loaded from the namespace and classname. Even though this class is in a .cs file in the root folder of the mod, the namespace decides where to find item and animation textures.
	namespace Items.Others
	{
		// Assigning multiple EquipType/Animation textures is easily done.
		internal class MeteorEmblem : ModItem
		{
            public override void SetStaticDefaults() {
			Tooltip.SetDefault("Showers meteors when you get hit");
		}
			public override void SetDefaults() {
				item.width = 28;
			    item.height = 28;
			    item.value = Item.sellPrice(silver: 5000);
			    item.rare = ItemRarityID.Purple;
			    item.accessory = true;
			    item.defense = 8;
			}

			public override void UpdateAccessory(Player player, bool hideVisual) 
            {
				// To assign the player the meteor rain effect, we can't do player.meteorrain = true because Player doesn't have meteorrain. Be sure to remember to call the GetModPlayer method to retrieve the ModPlayer instance attached to the specified Player.
				player.GetModPlayer<WhipPlayer>().MeteorRain = true;
			}
		}
	}
}