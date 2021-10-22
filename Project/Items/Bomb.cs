using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class Bomb : IItem
    {

        private IItemSprite sprite;

        public Rectangle BoundingBox => sprite.DestRectangle;

        public Bomb()
        {

            sprite = ItemSpriteFactory.Instance.CreateItemSprite(1, 4);

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
