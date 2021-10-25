using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface INPCState
    {
        public ISprite Sprite { get; }
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void Update(GameTime gameTime);
    }
}
