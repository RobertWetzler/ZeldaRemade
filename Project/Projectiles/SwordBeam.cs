using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Sound;
using Project.Sprites.ItemSprites;
using System;
using Project.Shading;

namespace Project.Projectiles
{
    class SwordBeam : Lightable, IProjectile
    {

        private IProjectileSprite sprite;

        public bool IsFinished => sprite.IsFinished() || !IsActive;
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        private Vector2 position;
        private Facing facing;
        private int xPos, yPos;
        private int velocity;
        private Vector2 offset;
        private float offsetVal;

        public SwordBeam(Facing facing, Vector2 position, bool isFriendly = true)
        {
            this.facing = facing;
            this.position = position;
            this.isFriendly = isFriendly;
            sprite = ItemSpriteFactory.Instance.CreateSwordSprite(this.facing);
            offsetVal = 30f;
            offset = Offset();
            velocity = 500;
            this.facing = facing;
            SoundManager.Instance.CreateSwordShootSound();
            this.lightColor = Color.Cyan;
            this.lightIntensity = 0.7f;
        }
        public Rectangle BoundingBox => SetBoundingBox();
        public CollisionType CollisionType => CollisionType.Projectile;
        public bool IsActive { get; set; } = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position + offset);
        }

        public void Update(GameTime gameTime)
        {

            switch (facing)
            {
                case Facing.Up:
                    yPos = -1;
                    break;
                case Facing.Down:
                    yPos = 1;
                    break;
                case Facing.Left:
                    xPos = -1;
                    break;
                case Facing.Right:
                    xPos = 1;
                    break;
            }

            this.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * xPos * velocity);
            this.position.Y += (float)(gameTime.ElapsedGameTime.TotalSeconds * yPos * velocity);

            sprite.Update(gameTime);
            if (!((IProjectile)this).IsInBounds())
            {
                ((IProjectile)this).Despawn();
            }
        }

        private Vector2 Offset()
        {

            offset = facing switch
            {
                Facing.Up => new Vector2(-offsetVal, 0),
                Facing.Down => new Vector2(-offsetVal, 0),
                Facing.Right => new Vector2(0, -offsetVal / 2f),
                Facing.Left => new Vector2(0, -offsetVal / 2f),
                _ => throw new NotImplementedException()
            };

            return offset;

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
