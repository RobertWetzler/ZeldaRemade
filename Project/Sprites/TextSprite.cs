using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class TextSprite : ISprite
    {
        public Texture2D texture { set => throw new NotImplementedException(); }
        public SpriteFont font { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(font, "Credits\n" +
                "Program Made By: Robert Wetzler\n" +
                "Sprites from: http://www.mariouniverse.com/wp-content/img/sprites/nes/\n" +
                "smb2/mario.png",
                new Vector2(5, 300),
                Color.Black);
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            // do nothing
        }
    }
}
