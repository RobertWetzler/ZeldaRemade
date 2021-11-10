using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface IText
    {
        public void Update(Rectangle windowBounds, GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
