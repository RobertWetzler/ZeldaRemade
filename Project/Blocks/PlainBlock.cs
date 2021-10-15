using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;

namespace Project.Items
{
    class BrickBlock : IBlockSprite
    {

        private IBlockSprite block;


        public BrickBlock()
        {

            block = BlockSpriteFactory.Instance.CreateBrickBlockSprite();

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            block.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            block.Update(gameTime);
        }
    }
}