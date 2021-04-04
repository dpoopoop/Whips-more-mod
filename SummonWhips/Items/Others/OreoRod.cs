using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SummonWhips.Projectiles.Minions;
 
 
namespace SummonWhips.Items.Others
{
    public class OreoRod : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Creates a floating oreo that shoots more oreos.
'The floating oreo is a projectile, that shoots a cookie which trails creamy projectiles that shatter into chasing bolts'");
		}
        public override void SetDefaults()
        { 
            item.mana = 15;
			item.damage = 100;     
            item.width = 40;    
            item.height = 40;     
            item.useTime = 25;   
            item.useAnimation = 25;    
            item.useStyle = 1;  
            item.noMelee = true; 
            item.knockBack = 2.5f;  
            item.value = Item.buyPrice(0, 10, 0, 0); 
            item.rare = ItemRarityID.Purple;  
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/oreopew").WithPitchVariance(.5f); 
            item.autoReuse = true;   
            item.shoot = mod.ProjectileType("OreoSentry");  
            item.summon = true;    
            item.sentry = true; 
            item.value = 2700000;
        }
 
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);  
            position = SPos;
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OreoBar>(), 18);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}