using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project.Blocks.Walls
{
    class Wall : IBlock
    {
        private Rectangle wallShape;
        public Rectangle BoundingBox => wallShape;
        public CollisionType CollisionType => CollisionType.Block;

        public Wall(Rectangle wallShape)
        {
            this.wallShape = wallShape;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
