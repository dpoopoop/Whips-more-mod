using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace ExpandedWeapons.Items.Melee
{
	public class FireSpinner : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fire Spinner"); 
			Tooltip.SetDefault("Spin with fire");
            //ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
        }

		public override void SetDefaults() 
		{
			item.damage = 12;
            item.crit = 0;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 100;
            item.value = Item.sellPrice(silver: 20);
            item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
           item.useTurn = false;
            item.channel = true;
            item.knockBack = 2f;
            item.shootSpeed = 1f;
            item.shoot = mod.ProjectileType("FireSpinnerProj");
           
            item.noMelee = true; 
            item.noUseGraphic = true; 
            
        }
        public override bool UseItemFrame(Player player)     //this defines what frame the player use when this weapon is used
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(8, 50);
            recipe.AddIngredient(9, 30);
            recipe.anyWood = true;
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Melee/FireSpinner");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw
           (
               texture,
               new Vector2
               (
                   item.position.X - Main.screenPosition.X + item.width * 0.5f,
                   item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
               ),
               new Rectangle(0, 0, texture.Width, texture.Height),
               Color.White,
               rotation,
               texture.Size() * 0.5f,
               scale,
               SpriteEffects.None,
               0f
           );
        }
    }
}