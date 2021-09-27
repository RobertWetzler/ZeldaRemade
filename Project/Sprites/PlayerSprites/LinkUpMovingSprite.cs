using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.PlayerSprites
{
    public class LinkUpMovingSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteColumn;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 50;
        private int totalFrame;

        public LinkUpMovingSprite(Texture2D playerSpriteSheet, int sheetRows, int sheetColumns)
        {
            this.palyerSpriteSheet = playerSpriteSheet;
            this.sheetRows = sheetRows;
            this.sheetColumns = sheetColumns;
            spriteRow = 0;
            spriteColumn = 4;

            totalFrame = 6;
        }


        void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                spriteColumn++;
                if (spriteColumn == totalFrame)
                {
                    spriteColumn = 4;
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
