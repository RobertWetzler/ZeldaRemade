using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class BlueArrow : IItems
    {

        private IItemSprite sprite;


        public BlueArrow()
        {

            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 1);

        }

        public Rectangle BoundingBox => sprite.DestRectangle;

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
