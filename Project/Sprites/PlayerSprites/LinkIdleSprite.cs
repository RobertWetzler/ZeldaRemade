using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.PlayerSprites
{
    public class LinkIdleSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows, spriteRow, spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;
        private bool facingLeft, finished;
        public LinkIdleSprite(Texture2D playerSpriteSheet, Facing facing)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            facingLeft = false;
            switch (facing)
            {
                case Facing.Up:
                    spriteColumn = 4;
                    break;
                case Facing.Down:
                    spriteColumn = 0;
                    break;
                case Facing.Left:
                    spriteColumn = 2;
                    facingLeft = true;
                    break;
                default:    //facing right
                    spriteColumn = 2;
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
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = frameWidth[spriteColumn].spriteW;
            int height = playerSpriteSheet.Height / sheetRows;
            int scale = 4;

            Rectangle source = new Rectangle(frameWidth[spriteColumn].totalW, spriteRow * height, width, height);
            Rectangle dest = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            if (facingLeft)
                spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);
            else
                spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White);
        }
    }
}
