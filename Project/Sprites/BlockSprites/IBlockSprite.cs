using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project.Sprites.BlockSprites
{
    public interface IBlockSprite: ICollidable
    {
        public Rectangle BoundingBox { get; }


        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void Update(GameTime gameTime);
    }
}
