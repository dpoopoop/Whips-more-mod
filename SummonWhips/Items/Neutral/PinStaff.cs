using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SummonWhips.Projectiles.Minions;
 
 
namespace SummonWhips.Items.Neutral
{
    public class PinStaff : NeutralClass
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Creates a floating pin shooter that shoots when enemies are near.
'It does not need aim, it just scatters these pins everywhere'");
		}
        public override void SafeSetDefaults()
        { 
            item.mana = 10;
			item.damage = 18;     
            item.width = 40;    
            item.height = 40;     
            item.useTime = 25;   
            item.useAnimation = 25;    
            item.useStyle = 1;  
            item.noMelee = true; 
            item.knockBack = 2.5f;  
            item.value = Item.buyPrice(0, 10, 0, 0); 
            item.rare = ItemRarityID.Green;  
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;   
            item.shoot = mod.ProjectileType("PinShooter");    
            item.sentry = true; 
            item.value = Item.sellPrice(silver: 400);
        }
 
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);  
            position = SPos;
            return true;
        }
    }
}