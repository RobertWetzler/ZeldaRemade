﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.ItemSprites
{
    class CandleSprite : IItemSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteColumn;

        private Texture2D arrowSpriteSheet;
        //Texture, Rows, Columns
        public CandleSprite(Texture2D arrowSpriteSheet, int sheetRows, int sheetColumns)
        {
            this.arrowSpriteSheet = arrowSpriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            spriteRow = 0;
            spriteColumn = 0;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = arrowSpriteSheet.Width / sheetColumns;
            int height = arrowSpriteSheet.Height / sheetRows;
            int scale = 2;

            Rectangle spriteRectangle = new Rectangle(spriteColumn * width, spriteRow * height, width, height);
            Rectangle destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(arrowSpriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
         
        }
    }
}
