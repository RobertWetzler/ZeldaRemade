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
        Rectangle DestRectangle { get; }
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, Color.White);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color);
    }
}