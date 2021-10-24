using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;

namespace Project.Blocks
{
    class Rectangle2 : IBlock
    {
        private IBlockSprite sprite;
        private Vector2 position;

        public Rectangle2(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreateRectangle2Sprite();
        }

        public Rectangle BoundingBox => sprite.DestRectangle;

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, this.position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
