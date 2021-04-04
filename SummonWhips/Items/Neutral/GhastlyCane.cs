using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SummonWhips.Projectiles.Minions;
 
 
namespace SummonWhips.Items.Neutral
{
    public class GhastlyCane : NeutralClass
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a floating ghast that shoots fireballs.
'Good thing these enemies don't know how to reflect fireballs'");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
        public override void SafeSetDefaults()
        { 
            item.mana = 12;
			item.damage = 40;     
            item.width = 40;    
            item.height = 40;     
            item.useTime = 25;   
            item.useAnimation = 25;    
            item.useStyle = 1;  
            item.noMelee = true; 
            item.knockBack = 6f;  
            item.rare = ItemRarityID.Pink;  
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;   
            item.shoot = mod.ProjectileType("Ghast");    
            item.sentry = true; 
            item.value = Item.sellPrice(silver: 900);
        }
 
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);  
            position = SPos;
            return true;
        }
    }
}