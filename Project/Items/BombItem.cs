using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;


namespace Project.Items
{
    class BombItem : IItems
    {

        private ISprite sprite;
        private Vector2 position;
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Item;

        public ItemType type => ItemType.Bomb;
        public BombItem(Vector2 position)

        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(1, 4);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
