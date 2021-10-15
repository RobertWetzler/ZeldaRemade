using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.BlockSprites
{
    public interface IBlockSprite
    {
        void Draw(SpriteBatch spriteBatch, Vector2 position);

        void Update(GameTime gametime);
    }
}
