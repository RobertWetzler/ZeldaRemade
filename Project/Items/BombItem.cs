using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
<<<<<<< HEAD:Project/Items/Bomb.cs
    class Bomb : IItem
    {

        private IItemSprite sprite;
        Vector2 position;
        public Rectangle BoundingBox => sprite.DestRectangle;

        public Bomb(Vector2 position)
=======
    class BombItem : IItems
    {

        private ISprite sprite;
        private Vector2 position;
        public Rectangle BoundingBox => sprite.DestRectangle;

        public BombItem(Vector2 position)
>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678:Project/Items/BombItem.cs
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
