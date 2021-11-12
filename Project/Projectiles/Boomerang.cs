using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Collision;
using Project.Sprites.ItemSprites;

namespace Project.Projectiles
{
    class Boomerang : IProjectile
    {

        private IWeaponSprite sprite;

        public bool IsFinished => sprite.isFinished() || !IsActive;
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        public Boomerang(Facing facing, Vector2 position, bool isFriendly = true)
        {
            sprite = ItemSpriteFactory.Instance.CreateBoomerangSprite(facing, position);
            this.isFriendly = isFriendly;
        }

        public Rectangle BoundingBox => SetBoundingBox();
        public CollisionType CollisionType => CollisionType.Projectile;
        public bool IsActive { get; set; } = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        /**
         * Decrease height of bounding box by about half
         */
        private Rectangle SetBoundingBox()
        {
            const float BOUNDINGBOX_OFFSET = 0.5f;
            float width = sprite.DestRectangle.Width;
            float height = sprite.DestRectangle.Height * (1 - BOUNDINGBOX_OFFSET);
            int x = sprite.DestRectangle.X;
            int y = sprite.DestRectangle.Y + ((sprite.DestRectangle.Height - (int)height) / 2);
            return new Rectangle(x, y, (int)width, (int)height);
        }
    }
}
