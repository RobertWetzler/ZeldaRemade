using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface ISprite
    {
        Texture2D texture { set; }
        void Update(Rectangle windowBounds, GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);

    }
}
