using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.PlayerSprites
{
    public class LinkWalkingSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows;
        private int spriteRow;
        private int spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 100;
        private int totalFrame;
        private Facing facing;

        public LinkWalkingSprite(Texture2D playerSpriteSheet, Facing facing)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            this.facing = facing;

            if (facing.CompareTo(Facing.Up) == 0)
            {
                spriteColumn = 4;
                totalFrame = 6;
            }
            else if (facing.CompareTo(Facing.Down) == 0)
            {
                spriteColumn = 0;
                totalFrame = 2;
            }
            else if (facing.CompareTo(Facing.Left) == 0)
            {
                spriteColumn = 2;   //TODO: need to change to 6 after adding left sprites
                totalFrame = 4;     //TODO: need to change to 8 after adding left sprites
            }
            else if (facing.CompareTo(Facing.Right) == 0)
            {
                spriteColumn = 2;
                totalFrame = 4;
            }

            frameWidth = new List<(int spriteW, int totalW)>();
            frameWidth.Add((16, 0));
            frameWidth.Add((16, 17));
            frameWidth.Add((16, 34));
            frameWidth.Add((16, 51));
            frameWidth.Add((16, 68));
            frameWidth.Add((16, 85));
            //frameWidth.Add((16, 102));    last two frame for adding left sprites
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
                    if (facing.CompareTo(Facing.Up) == 0)
                        spriteColumn = 4;
                    else if (facing.CompareTo(Facing.Down) == 0)
                        spriteColumn = 0;
                    else if (facing.CompareTo(Facing.Left) == 0)
                        spriteColumn = 2;      //TODO: need to change to 6 after adding left sprites
                    else if (facing.CompareTo(Facing.Right) == 0)
                        spriteColumn = 2;
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
