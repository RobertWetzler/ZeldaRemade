using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites
{
    class SmallHudSprite : ISprite
    {
        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        private Rectangle sourceRectangle;
        
        public SmallHudSprite(Texture2D texture)
        {
            this.spriteSheet = texture;
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);

        }

        public Rectangle DestRectangle => destRectangle;
        
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            const int scale = 4;
            int width = spriteSheet.Width * scale;
            int height = spriteSheet.Height * scale;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(spriteSheet, destRectangle, sourceRectangle, color);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
