using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;
using Project.Collision;
using Project.Entities;

namespace Project.Weapons
{
    class Flame : ICollidable
    {

        private IWeaponSprite sprite;

        public Flame (Facing facing, Vector2 position)
        {

            sprite = ItemSpriteFactory.Instance.CreateFlameSprite(facing, position);
        }

        public Rectangle BoundingBox => sprite.DestRectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
