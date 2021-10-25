using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{

  
    class BlueBoomerangItem : IItem
    {

        private ISprite sprite;
        private Vector2 position;

        public BlueBoomerangItem(Vector2 position)

        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(1, 1);

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