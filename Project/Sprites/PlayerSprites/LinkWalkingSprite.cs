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
        private int sheetColumns;
        private int spriteRow;
        private int spriteColumn;

        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 100;
        private int totalFrame;
        private Facing facing;

        public LinkWalkingSprite(Texture2D playerSpriteSheet, Facing facing)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            sheetColumns = 6;
            this.facing = facing;

            if (facing.CompareTo(Facing.Up) == 0)
            {
                spriteRow = 0;
                spriteColumn = 4;
                totalFrame = 6;
            }
            else if (facing.CompareTo(Facing.Down) == 0)
            {
                spriteRow = 0;
                spriteColumn = 0;
                totalFrame = 2;
            }
            else if (facing.CompareTo(Facing.Left) == 0)
            {
                spriteRow = 0;
                spriteColumn = 2;
                totalFrame = 4;
            }
            else if (facing.CompareTo(Facing.Right) == 0)
            {
                spriteRow = 0;
                spriteColumn = 2;
                totalFrame = 4;
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
                    if (facing.CompareTo(Facing.Up) == 0)
                        spriteColumn = 4;
                    else if (facing.CompareTo(Facing.Down) == 0)
                        spriteColumn = 0;
                    else if (facing.CompareTo(Facing.Left) == 0)
                        spriteColumn = 2;
                    else if (facing.CompareTo(Facing.Right) == 0)
                        spriteColumn = 2;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = playerSpriteSheet.Width / sheetColumns;
            int height = playerSpriteSheet.Height / sheetRows;
            int scale = 4;

            Rectangle source = new Rectangle(spriteColumn * width, spriteRow * height, width, height);
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White);
        }
    }
}
