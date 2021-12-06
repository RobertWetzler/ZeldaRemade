using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;

namespace Project.Blocks
{
    class BlackBlock : IBlock
    {

        private ISprite sprite;
        private Vector2 position;

        public BlackBlock(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateBlackBlockSprite();

        }

        public Rectangle BoundingBox => sprite.DestRectangle;

        public CollisionType CollisionType => CollisionType.BlackBlock;

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
