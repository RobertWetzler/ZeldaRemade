using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface INPCState
    {
        public IEnemySprite Sprite { get; }
        void Draw(SpriteBatch spriteBatch, float xPos, float yPos);
        void Update(GameTime gameTime);
    }
}
