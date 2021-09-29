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

        //TODO: add parameter: Item item
        public void UseItem();
        void Update(Rectangle windowBounds, GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
