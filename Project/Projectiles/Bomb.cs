using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;
using Project.Collision;
using Project.Entities;

namespace Project.Projectiles
{
    class Bomb : IProjectile
    {

        private IWeaponSprite sprite;
        public bool IsFinished => sprite.isFinished();
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        public Bomb (Facing facing, Vector2 position, bool isFriendly = true)
        {
            sprite = ItemSpriteFactory.Instance.CreateBombSprite(facing, position);
            this.isFriendly = isFriendly;
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
