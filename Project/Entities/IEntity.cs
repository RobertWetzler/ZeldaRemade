using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public interface IEntity
    {
        public void TakeDamage(int damage);

        void Update(Rectangle windowBounds, GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Draw(spriteBatch, gameTime, Color.White);
        }
        void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color);
    }
}
