using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
<<<<<<< HEAD:Project/Items/BlueBoomerang.cs
    class BlueBoomerang : IItem
    {

        private IItemSprite sprite;
        private Vector2 position;

        public BlueBoomerang(Vector2 position)
=======
    class BlueBoomerangItem : IItems
    {

        private ISprite sprite;
        private Vector2 position;

        public BlueBoomerangItem(Vector2 position)
>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678:Project/Items/BlueBoomerangItem.cs
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