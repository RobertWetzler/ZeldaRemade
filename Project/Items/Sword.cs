using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class Sword : IItems
    {

        private ISprite sprite;

        public Rectangle BoundingBox => sprite.DestRectangle;

        public Sword()
        {

            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 10);

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
