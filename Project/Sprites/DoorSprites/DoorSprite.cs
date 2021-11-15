using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites
{
    public class DoorSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle sourceRect;
        private Rectangle destRectangle;
        private int width;
        private int height;

        public Rectangle DestRectangle => destRectangle;
        public DoorSprite(Texture2D texture, DoorType doorType, int row, int numColumns, int numRows)
        {
            this.texture = texture;

            width = texture.Width / numColumns;
            height = texture.Height / numRows;

            int offset = 0;
            if (row > 0)
            {
                offset += row;
            }

            switch (doorType)
            {
                case DoorType.OPEN:
                    sourceRect = new Rectangle(1 * width + 1, row * height + offset, width, height);
                    break;
                case DoorType.CLOSED:
                    sourceRect = new Rectangle(3 * width + 3, row * height + offset, width, height);
                    break;
                case DoorType.KEY_CLOSED:
                    sourceRect = new Rectangle(2 * width + 2, row * height + offset, width, height);
                    break;
                case DoorType.BOMB_OPEN:
                    sourceRect = new Rectangle(4 * width + 4, row * height + offset, width, height);
                    break;
                case DoorType.WALL:
                    sourceRect = new Rectangle(0 * width, row * height + offset, width, height);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            const int scale = 4;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(texture, destRectangle, sourceRect, color);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
