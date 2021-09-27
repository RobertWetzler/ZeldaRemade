using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.PlayerSprites
{
    public class LinkDownMovingSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteColumn;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 50;
        private int totalFrame;

        public LinkDownMovingSprite(Texture2D playerSpriteSheet, int sheetRows, int sheetColumns)
        {
            this.palyerSpriteSheet = playerSpriteSheet;
            this.sheetRows = sheetRows;
            this.sheetColumns = sheetColumns;
            spriteRow = 0;
            spriteColumn = 0;

            totalFrame = 2;
        }


        void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                spriteColumn++;
                if(spriteColumn == totalFrame)
                {
                    spriteColumn = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = playerSpriteSheet.Width / sheetColumns;
            int height = playerSpriteSheet.Height
            int scale = 4;

            Rectangle source = new Rectangle(spriteColumn * width, spriteRow * height, width, height);
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White);
        }
    }
}
