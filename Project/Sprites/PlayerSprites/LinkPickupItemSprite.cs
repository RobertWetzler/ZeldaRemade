using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project.Sprites.PlayerSprites
{
    public class LinkPickupItemSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows;

        private int spriteRow;
        private int spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 500;
        private int totalFrame;
        private bool cycleOnce;

        public LinkPickupItemSprite(Texture2D playerSpriteSheet)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            spriteColumn = 0;
            totalFrame = 2;
            cycleOnce = false;


            frameWidth = new List<(int spriteW, int totalW)>();
            frameWidth.Add((16, 0));
            frameWidth.Add((16, 17));
        }
        public bool IsFinished
        {
            get
            {
                return cycleOnce;
            }
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame;
                spriteColumn++;
                if (spriteColumn == totalFrame)
                {
                    cycleOnce = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int height = playerSpriteSheet.Height / sheetRows;
            int scale = 4;
            if (!cycleOnce)
            {
                int width = frameWidth[spriteColumn].spriteW;
                Rectangle source = new Rectangle(frameWidth[spriteColumn].totalW, spriteRow * height, width, height);
                Rectangle dest = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
                spriteBatch.Draw(playerSpriteSheet, dest, source, color);
            }
            else
            {
                int width = frameWidth[0].spriteW;
                Rectangle source = new Rectangle(frameWidth[0].totalW, spriteRow * height, width, height);
                Rectangle dest = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
                spriteBatch.Draw(playerSpriteSheet, dest, source, color);
            }
        }
    }
}
