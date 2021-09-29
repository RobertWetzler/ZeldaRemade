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
        private int sheetRows;
        private int spriteRow;
        private int spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 100;
        private int totalFrame;
        private bool facingRight;

        public LinkUseSwordSidewaysSprite(Texture2D playerSpriteSheet, bool facingRight)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            this.facingRight = facingRight;

            if (facingRight)
            {
                spriteColumn = 0;
                totalFrame = 4;
            }
            else   // facing left
            {
                spriteColumn = 0;   //TODO: need to change to 4 after adding left sprites
                totalFrame = 4;     //TODO: need to change to 8 after adding left sprites
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

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondPerFrame)
            {
                timeSinceLastFrame -= millisecondPerFrame; 
                spriteColumn++;
                if (spriteColumn == totalFrame)
                {
                    if (facingRight)
                        spriteColumn = 0;
                    else
                        spriteColumn = 0;   //TODO: need to change to 4 after adding left sprites

                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = frameWidth[spriteColumn].spriteW;
            int height = playerSpriteSheet.Height / sheetRows;
            int scale = 4;

            Rectangle source = new Rectangle(frameWidth[spriteColumn].totalW, spriteRow * height, width, height);
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White);
        }
    }
}
