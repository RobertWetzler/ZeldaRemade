using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface IItems
    {
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void Update(GameTime gameTime);

    }
}
