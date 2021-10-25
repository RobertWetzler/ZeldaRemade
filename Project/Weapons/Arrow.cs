using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Entities;
using Project.Sprites.ItemSprites;
using Project.Collision;

namespace Project.Weapons
{
    class Arrow : ICollidable
    {

        private IWeaponSprite sprite;

        public Arrow(Facing facing, Vector2 position)
        {
            
            sprite = ItemSpriteFactory.Instance.CreateArrowSprite(facing, position);
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
