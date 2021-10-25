using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class Bow : IItem
    {

<<<<<<< HEAD
        private IItemSprite sprite;
=======
        private ISprite sprite;
>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678
        private Vector2 position;
        public Rectangle BoundingBox => sprite.DestRectangle;

        public Bow(Vector2 position)
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 7);

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
