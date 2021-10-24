using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.BlockSprites
{
    class Rectangle2Sprite : ISprite
    {
        private Texture2D blockSpriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;


        public Rectangle2Sprite(Texture2D blockSpriteSheet)
        {
            this.blockSpriteSheet = blockSpriteSheet;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int width = blockSpriteSheet.Width;
            int height = blockSpriteSheet.Height;
            int scale = 4;
            Rectangle source = new Rectangle(0, 0, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(blockSpriteSheet, destRectangle, source, Color.White);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
