using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;

namespace Project.Items
{
    class LeftFacingDragonBlock : IBlockSprite
    {

        private IBlockSprite block;


        public LeftFacingDragonBlock()
        {

            block = BlockSpriteFactory.Instance.CreateLeftFacingDragonBlockSprite();

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
