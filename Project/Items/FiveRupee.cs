using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class FiveRupee : IItems
    {

        private IItemSprite sprite;


        public FiveRupee()
        {

            sprite = ItemSpriteFactory.Instance.CreateRupeeSprite();

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
