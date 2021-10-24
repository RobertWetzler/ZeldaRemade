using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project.Sprites.PlayerSprites
{
    public class LinkUseSwordSidewaysSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows, spriteRow, spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 100;
        private int totalFrame;
        private bool facingRight;
        private bool cycleOnce;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public LinkUseSwordSidewaysSprite(Texture2D playerSpriteSheet, bool facingRight)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            this.facingRight = facingRight;
            cycleOnce = false;

            spriteColumn = 0;
            totalFrame = 4;

            frameWidth = new List<(int spriteW, int totalW)>();
            frameWidth.Add((16, 0));
            frameWidth.Add((27, 17));
            frameWidth.Add((23, 45));
            frameWidth.Add((19, 69));
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
                if (spriteColumn < totalFrame - 1)
                {
                    spriteColumn++;
                }
                else
                {
                    cycleOnce = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int height = playerSpriteSheet.Height / sheetRows;
            int scale = 4;
            int width = frameWidth[spriteColumn].spriteW;
            Rectangle source = new Rectangle(frameWidth[spriteColumn].totalW, spriteRow * height, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);

            if (facingRight)
            {
                spriteBatch.Draw(playerSpriteSheet, destRectangle, source, color);
            }
            else
            {
                switch (spriteColumn)
                {
                    case 1:
                        destRectangle = new Rectangle((int)position.X - (11 * scale), (int)position.Y, width * scale, height * scale);
                        break;
                    case 2:
                        destRectangle = new Rectangle((int)position.X - (7 * scale), (int)position.Y, width * scale, height * scale);
                        break;
                    case 3:
                        destRectangle = new Rectangle((int)position.X - (3 * scale), (int)position.Y, width * scale, height * scale);
                        break;
                }
                spriteBatch.Draw(playerSpriteSheet, destRectangle, source, color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
        }
    }
}
