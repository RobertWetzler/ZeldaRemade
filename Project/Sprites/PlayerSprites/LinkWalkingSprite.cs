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
        private int sheetRows, spriteRow, spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;
        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 100;
        private int totalFrame;
        private Facing facing;
        private bool facingLeft, finished;

        public LinkWalkingSprite(Texture2D playerSpriteSheet, Facing facing)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            this.facing = facing;
            facingLeft = false;
            finished = false;

            switch (facing)
            {
                case Facing.Up:
                    spriteColumn = 4;
                    totalFrame = 6;
                    break;
                case Facing.Down:
                    spriteColumn = 0;
                    totalFrame = 2;
                    break;
                case Facing.Right:
                    spriteColumn = 2;
                    totalFrame = 4;
                    break;
                default:
                    spriteColumn = 2;
                    totalFrame = 4;
                    facingLeft = true;
                    break;
            }

            frameWidth = new List<(int spriteW, int totalW)>();
            frameWidth.Add((16, 0));
            frameWidth.Add((16, 17));
            frameWidth.Add((16, 34));
            frameWidth.Add((16, 51));
            frameWidth.Add((16, 68));
            frameWidth.Add((16, 85));
        }

        public bool IsFinished
        {
            get
            {
                return finished;
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
                    switch (facing)
                    {
                        case (Facing.Up):
                            spriteColumn = 4;
                            break;
                        case (Facing.Down):
                            spriteColumn = 0;
                            break;
                        case (Facing.Left):
                            spriteColumn = 2;
                            break;
                        default:    //facing right
                            spriteColumn = 2;
                            break;
                    }
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
            if (facingLeft)
                spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            else
                spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White);
        }
    }
}
