using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.ItemSprites
{
    public interface IProjectileSprite
    {
        public Rectangle DestRectangle { get; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 position);

        bool IsFinished();

    }
}
