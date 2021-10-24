using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;

namespace Project.Blocks
{
    class MoveableBlock
    {
        private IBlockSprite sprite;
        private Vector2 position;

        public MoveableBlock(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreatePyramidBlockSprite();

        }

        public Rectangle BoundingBox => sprite.BoundingBox;

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
