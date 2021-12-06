using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Shading;

namespace Project.Items
{
    class BlueArrowItem : Lightable, IItems
    {

        private ISprite sprite;
        private Vector2 position;

        public BlueArrowItem(Vector2 position)
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 1);
            lightColor = Color.Blue;
        }
        public ItemType type => ItemType.Blue_Arrow;
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Item;

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
