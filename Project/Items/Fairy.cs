using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Collision;

namespace Project.Items
{
    class Fairy : IItems
    {

        private ISprite sprite;
        private Vector2 position;

        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Item;

        public Fairy(Vector2 position)
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateFairySprite();

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