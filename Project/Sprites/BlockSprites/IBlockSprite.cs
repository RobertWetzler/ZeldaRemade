using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.BlockSprites
{
    public interface IBlockSprite
    {
        public Rectangle DestRectangle { get; }
        void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
