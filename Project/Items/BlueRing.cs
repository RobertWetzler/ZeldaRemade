using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class BlueRing : IItems
    {

        private IItemSprite sprite;

        public Rectangle BoundingBox => sprite.DestRectangle;

        public BlueRing()
        {

            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 6);

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
