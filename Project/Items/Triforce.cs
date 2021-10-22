using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class Triforce: IItem
    {

        private IItemSprite sprite;

        public Rectangle BoundingBox => sprite.DestRectangle;

        public Triforce()
        {

            sprite = ItemSpriteFactory.Instance.CreateTriforceSprite();

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
