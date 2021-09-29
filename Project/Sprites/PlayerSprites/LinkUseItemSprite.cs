using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.PlayerSprites
{
    public class LinkUseItemSprite : IPlayerSprite
    {
        private Texture2D playerSpriteSheet;
        private int sheetRows;
        private int spriteRow;
        private int spriteColumn;
        private List<(int spriteW, int totalW)> frameWidth;

        public LinkUseItemSprite(Texture2D playerSpriteSheet, Facing facing)
        {
            this.playerSpriteSheet = playerSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            if (facing.CompareTo(Facing.Up) == 0)
            {
                spriteColumn = 2;
            }
            else if (facing.CompareTo(Facing.Down) == 0)
            {
                spriteColumn = 0;
            }
            else if (facing.CompareTo(Facing.Left) == 0)
            {
                spriteColumn = 1;   // TODO: need to change to 3 after adding left sprite
            }
            else if (facing.CompareTo(Facing.Right) == 0)
            {
                spriteColumn = 1;
            }

            frameWidth = new List<(int w, int s)>();
            frameWidth.Add((16, 0));
            frameWidth.Add((16, 17));
            frameWidth.Add((16, 34));
            // frameWidth.Add((16, 51));   // last frame for left sprite
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
            spriteBatch.Draw(playerSpriteSheet, dest, source, Color.White);
        }
    }
}
