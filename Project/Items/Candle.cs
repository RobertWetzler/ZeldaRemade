using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.Items
{
    class Candle : IItems
    {

        private ISprite sprite;
        private Vector2 position;

        public Rectangle BoundingBox => sprite.DestRectangle;

        public Candle(Vector2 position)
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 2);

        }

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
