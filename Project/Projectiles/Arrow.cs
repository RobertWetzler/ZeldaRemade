using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
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
        }

        public Rectangle BoundingBox => sprite.DestRectangle;

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
    }
}
