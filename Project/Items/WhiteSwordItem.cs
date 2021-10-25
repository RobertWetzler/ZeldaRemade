using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
<<<<<<< HEAD:Project/Items/WhiteSword.cs
    class WhiteSword : IItem
    {

        private IItemSprite sprite;
        private Vector2 position;
        public Rectangle BoundingBox => sprite.DestRectangle;

        public WhiteSword(Vector2 position)
=======
    class WhiteSwordItem : IItems
    {

        private ISprite sprite;
        private Vector2 position;
        public Rectangle BoundingBox => sprite.DestRectangle;

        public WhiteSwordItem(Vector2 position)
>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678:Project/Items/WhiteSwordItem.cs
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(1, 10);

        }
<<<<<<< HEAD:Project/Items/WhiteSword.cs
=======

>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678:Project/Items/WhiteSwordItem.cs
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
