using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;

namespace Project.Blocks
{
    class Rectangle1 : IBlock
    {
        private ISprite sprite;
        private Vector2 position;

        public Rectangle1(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateRectangle1Sprite();
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
