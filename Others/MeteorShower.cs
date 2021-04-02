using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummonWhips.Items.Others 
{
    public class MeteorShower : ModItem
    {
        public override void SetStaticDefaults() 
        {
                Tooltip.SetDefault(@"Showers lots of meteors.
'How to kill all dinosaurs: Use this weapon'");
            Item.staff[item.type] = true; 
        }
        public override void SetDefaults()
        {
            item.damage = 250; 
            item.magic = true; 
            item.width = 64; 
            item.height = 64; 
            item.useTime = 10; 
            item.useAnimation = 10; 
            item.useStyle = 5; 
            item.knockBack = 5f; 
            item.value = 1500000; 
            item.rare = ItemRarityID.Purple;
            item.autoReuse = true; 
            item.shoot = ProjectileID.Meteor1;
            item.shootSpeed = 12;
            item.mana = 15; 
        }
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4;
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(50, 80) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-30, 30) * 0.02f;
                float SpeedY = num17 + (float)Main.rand.Next(-30, 30) * 0.02f;
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.MeteoriteBar, 50);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ModContent.ItemType<MeteorCore>(), 1);
            recipe.AddTile(412); 
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}