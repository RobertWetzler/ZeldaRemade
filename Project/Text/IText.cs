using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project;

namespace Project
{
    public interface IText
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);

    }
}
