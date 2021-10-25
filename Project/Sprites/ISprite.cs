using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface ISprite
    {
        public Rectangle DestRectangle { get; }
        void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, Color.White);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color);

    }
}
