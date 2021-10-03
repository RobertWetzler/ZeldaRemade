﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project.Sprites.ItemSprites
{
    class ItemSprite : IItemSprite
    {

        private int spriteWidth;
        private int spriteHeight;

        public int spriteRow;
        public int spriteColumn;

        private Texture2D spriteSheet;
        //Texture, Rows, Columns
        public ItemSprite(Texture2D spriteSheet, int spriteWidth, int spriteHeight, int spriteRow, int spriteColumn)
        {
            this.spriteSheet = spriteSheet;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;

            this.spriteRow = spriteRow;
            this.spriteColumn = spriteColumn;

            

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = spriteWidth;
            int height = spriteHeight;
            int scale = 2;

            Rectangle spriteRectangle = new Rectangle(spriteColumn * width, spriteRow * height, width, height);
            Rectangle destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
           
        }

       
    }
}