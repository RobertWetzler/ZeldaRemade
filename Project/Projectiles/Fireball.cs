using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Shading;
using Project.Sprites.ItemSprites;
using System;

namespace Project.Projectiles
{
    class Fireball : FireLight, IProjectile
    {
        private IProjectileSprite sprite;
        public bool IsFinished => sprite.IsFinished() || !IsActive;
        private bool isFriendly;
        private Vector2 position;
        public bool IsFriendly => isFriendly;
        public Fireball(Facing facing, Vector2 position, bool isFriendly = true)
        {
            this.position = position;
            sprite = facing switch
            {
                Facing.Up => ItemSpriteFactory.Instance.CreateLeftUpFireballSprite(position),
                Facing.Left => ItemSpriteFactory.Instance.CreateLeftFireballSprite(position),
                Facing.Down => ItemSpriteFactory.Instance.CreateLeftDownFireballSprite(position),
                _ => throw new NotImplementedException()
            };
            this.lightColor = Color.Red;
            this.isFriendly = isFriendly;
        }

        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Projectile;
        public bool IsActive { get; set; } = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (!((IProjectile)this).IsInBounds())
            {
                ((IProjectile)this).Despawn();
            }
        }
    }
}
