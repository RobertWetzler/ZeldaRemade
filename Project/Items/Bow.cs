using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class Bow : IItem
    {

        private IItemSprite sprite;

        public Rectangle BoundingBox => sprite.DestRectangle;

        public Bow()
        {

            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 7);

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
