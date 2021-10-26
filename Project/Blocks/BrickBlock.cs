using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.Blocks
{
    class BrickBlock : IBlock
    {
        private ISprite sprite;
        private Vector2 position;


        public BrickBlock(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateBrickBlockSprite();

        }

        public Rectangle BoundingBox => sprite.DestRectangle;

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
