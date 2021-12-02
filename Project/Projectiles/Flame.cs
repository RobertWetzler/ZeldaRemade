using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Sprites.ItemSprites;
using Project.Sound;
using Project.Shading;

namespace Project.Projectiles
{
    class Flame : FireLight, IProjectile
    {
        private IProjectileSprite sprite;
        public bool IsFinished => sprite.IsFinished() || !IsActive;
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        private Vector2 position;
        private Facing facing;
        private float timer;
        private int xPos, yPos;
        private int velocity;

        public Flame(Facing facing, Vector2 position, bool isFriendly = true)
        {
            this.facing = facing;
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateFlameSprite(this.facing);
            this.isFriendly = isFriendly;
            SoundManager.Instance.CreateCandleSound();
            velocity = 350;
            this.lightColor = Color.Red;
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

            switch (this.facing)
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
        }

        /**
         * Shrink Bounding box by a little bit on each side
         */
        private Rectangle SetBoundingBox()
        {
            const float BOUNDINGBOX_OFFSET = 0.1f;
            float width = sprite.DestRectangle.Width * (1 - BOUNDINGBOX_OFFSET);
            float height = sprite.DestRectangle.Height * (1 - BOUNDINGBOX_OFFSET);
            int x = sprite.DestRectangle.X + ((sprite.DestRectangle.Width - (int)width) / 2);
            int y = sprite.DestRectangle.Y + ((sprite.DestRectangle.Height - (int)height) / 2);
            return new Rectangle(x, y, (int)width, (int)height);
        }
    }
}
