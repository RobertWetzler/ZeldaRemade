using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;

namespace Project.Items
{
    class FiveRupee : IItems
    {

        private ISprite sprite;
        private Vector2 position;

        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Item;
        public ItemType type => ItemType.FiveRupee;
        public FiveRupee(Vector2 position)
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateRupeeSprite();

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
