using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;

namespace Project.Items
{
    class StairBlock : IBlockSprite
    {

        private IBlockSprite block;


        public StairBlock()
        {

            block = BlockSpriteFactory.Instance.CreateStairBlockSprite();

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