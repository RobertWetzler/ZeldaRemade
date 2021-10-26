using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.Items
{
    class BlueBottle : IItems
    {

        private ISprite sprite;
        private Vector2 position;

        public BlueBottle(Vector2 position)
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(1, 3);

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
