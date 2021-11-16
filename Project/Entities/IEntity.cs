using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface IEntity
    {
        public void TakeDamage(int damage);
        public int Health { get; set; }
        void Update(Rectangle windowBounds, GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Draw(spriteBatch, gameTime, Color.White);
        }
        void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color);
    }
}
