using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Collision;
using Project.Sprites.ItemSprites;
using System;

namespace Project.Projectiles
{
    class Fireball : IProjectile
    {
        private IWeaponSprite sprite;
        public bool IsFinished => sprite.isFinished() || !IsActive;
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        public Fireball(Facing facing, Vector2 position, bool isFriendly = true)
        {
            sprite = facing switch
            {
                Facing.Up => ItemSpriteFactory.Instance.CreateLeftUpFireballSprite(position),
                Facing.Left => ItemSpriteFactory.Instance.CreateLeftFireballSprite(position),
                Facing.Down => ItemSpriteFactory.Instance.CreateLeftDownFireballSprite(position),
                _ => throw new NotImplementedException()
            };
            this.isFriendly = isFriendly;
        }

        public Rectangle BoundingBox => sprite.DestRectangle;
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
    }
}
