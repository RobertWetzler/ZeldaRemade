using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.PlayerSprites
{
    public interface IPlayerSprite
    {
        bool IsFinished
        {
            get;
        }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}