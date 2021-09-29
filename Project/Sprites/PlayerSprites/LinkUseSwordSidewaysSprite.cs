using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.PlayerSprites
{
    public class LinkUseSwordSidewaysSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows, spriteRow, spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 500;
        private int totalFrame;
        private bool facingRight;
        private bool cycleOnce;

        public LinkUseSwordSidewaysSprite(Texture2D playerSpriteSheet, bool facingRight)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            this.facingRight = facingRight;
            cycleOnce = false;

            if (facingRight)
            {
                spriteColumn = 0;
                totalFrame = 4;
            }
            else   //facing left
            {
                spriteColumn = 0;  // need to change to 4
                totalFrame = 4;    // need to change to 8
            }
            frameWidth = new List<(int spriteW, int totalW)>();
            frameWidth.Add((16,0));
            frameWidth.Add((27,17));
            frameWidth.Add((23,45));
            frameWidth.Add((19,69));
            //frameWidth.Add((16, 68));     last four frame for adding left sprites
            //frameWidth.Add((16, 85));
            //frameWidth.Add((16, 102));    
            //frameWidth.Add((16, 119));
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int height = playerSpriteSheet.Height / sheetRows;
            int scale = 4;
            int width;
            Rectangle source;

            if (!cycleOnce)
            {
                width = frameWidth[spriteColumn].spriteW;
                source = new Rectangle(frameWidth[spriteColumn].totalW, spriteRow * height, width, height);
            }
            else
            {
                width = frameWidth[0].spriteW;
                source = new Rectangle(frameWidth[0].totalW, spriteRow * height, width, height);
            }
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            if (facingRight)
                spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White);
            else
                spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
        }
    }
}
