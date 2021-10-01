using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.PlayerSprites
{
    public class LinkUseSwordUpwardsSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows;
        private int spriteRow;
        private int spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 500;      // frequency of animation
        private int totalFrame;
        private bool cycleOnce;

        public LinkUseSwordUpwardsSprite(Texture2D playerSpriteSheet)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            spriteColumn = 0;
            totalFrame = 4;
            cycleOnce = false;

            frameWidth = new List<(int spriteW, int totalW)>();
            frameWidth.Add((16, 0));
            frameWidth.Add((16, 17));
            frameWidth.Add((16, 34));
            frameWidth.Add((16, 51));
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int height = playerSpriteSheet.Height / sheetRows;
            int scale = 4;
            int width = frameWidth[spriteColumn].spriteW;

            Rectangle source = new Rectangle(frameWidth[spriteColumn].totalW, spriteRow * height, width, height);
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White);
        }
    }
}
