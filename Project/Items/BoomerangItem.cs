using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
<<<<<<< HEAD:Project/Items/Boomerang.cs
    class Boomerang : IItem
    {

        private IItemSprite sprite;
        private Vector2 position;
        public Rectangle BoundingBox => sprite.DestRectangle;

        public Boomerang(Vector2 position)
=======
    class BoomerangItem : IItems
    {

        private ISprite sprite;
        private Vector2 position;

        public Rectangle BoundingBox => sprite.DestRectangle;

        public BoomerangItem(Vector2 position)
>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678:Project/Items/BoomerangItem.cs
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(1, 0);

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