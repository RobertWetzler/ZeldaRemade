﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Collision;
using Project.Sprites.ItemSprites;

namespace Project.Projectiles
{
    class Sword : IProjectile
    {

        private IWeaponSprite sprite;
        private Facing facing;
        public bool IsFinished => sprite.isFinished() || !IsActive;
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        public Sword(Facing facing, Vector2 position, bool isFriendly = true)
        {
            sprite = ItemSpriteFactory.Instance.CreateSwordSprite(facing, position);
            this.isFriendly = isFriendly;
            this.facing = facing;
            SoundManager.Instance.CreateSwordShootSound();
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
         * Shrink sword bounding box from 16x16 to be 16x3 or 3x16 (before scaling)
         */
        private Rectangle SetBoundingBox()
        {
            const float BOUNDINGBOX_OFFSET = 0.8125f;
            int width = sprite.DestRectangle.Width;
            int height = sprite.DestRectangle.Height;
            int x = sprite.DestRectangle.X;
            int y = sprite.DestRectangle.Y;
            switch (facing)
            {
                case Facing.Down:
                case Facing.Up:
                    width = (int)(sprite.DestRectangle.Width * (1 - BOUNDINGBOX_OFFSET));
                    x = sprite.DestRectangle.X + ((sprite.DestRectangle.Width - width) / 2);
                    break;
                case Facing.Left:
                case Facing.Right:
                    height = (int)(sprite.DestRectangle.Height * (1 - BOUNDINGBOX_OFFSET));
                    y = sprite.DestRectangle.Y + ((sprite.DestRectangle.Height - height) / 2);
                    break;
            }
            return new Rectangle(x, y, width, height);
        }
    }
}
