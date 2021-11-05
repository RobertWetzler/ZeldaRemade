using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;

namespace Project.Blocks
{
    class Rectangle2 : IBlock
    {
        private ISprite sprite;
        private Vector2 position;

        public Rectangle2(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateRectangle2Sprite();
        }

        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Block;


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
