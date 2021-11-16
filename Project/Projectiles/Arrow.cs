using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Collision;
using Project.Sprites.ItemSprites;
using System;

namespace Project.Projectiles
{
    class Arrow : IProjectile
    {
        private IProjectileSprite sprite;
        public bool IsFinished => sprite.IsFinished() || !IsActive;

        private bool isFriendly;
        private int yPos, xPos;
        private float timer;
        public Vector2 position;
        private Facing facing;
        private int velocity;
        private Direction direction;
        public bool IsFriendly => isFriendly;
        public Arrow(Facing facing, Vector2 position, bool isFriendly = true)
        {
            this.facing = facing;
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateArrowSprite(this.facing);
            this.isFriendly = isFriendly;

            velocity = 400;

            direction = this.facing switch
            {
                Facing.Up => Direction.Up,
                Facing.Down => Direction.Down,
                Facing.Right => Direction.Right,
                Facing.Left => Direction.Left,
                _ => throw new NotImplementedException()
            };
            SoundManager.Instance.CreateArrowBoomerangSound();
        }

        public Rectangle BoundingBox => SetBoundingBox();
        public CollisionType CollisionType => CollisionType.Projectile;

        public bool IsActive { get; set; } = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > 1500)
                direction = Direction.Stop;

            switch (direction)
            {
                case Direction.Up:
                    yPos = -1;
                    break;
                case Direction.Down:
                    yPos = 1;
                    break;
                case Direction.Left:
                    xPos = -1;
                    break;
                case Direction.Right:
                    xPos = 1;
                    break;
                case Direction.Stop:
                    xPos = 0;
                    yPos = 0;
                    break;
            }

            this.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * xPos * velocity);
            this.position.Y += (float)(gameTime.ElapsedGameTime.TotalSeconds * yPos * velocity);

            sprite.Update(gameTime);
            

        }

        /**
         * Shrink bounding box from 16x16 to be 16x5 or 5x16 (before scaling)
         */
        private Rectangle SetBoundingBox()
        {
            const float BOUNDINGBOX_OFFSET = 0.6875f;
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
