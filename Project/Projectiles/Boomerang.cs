using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Projectiles
{
    class Boomerang : IProjectile
    {

        private IProjectileSprite sprite;
        public bool IsFinished => sprite.IsFinished() || !IsActive;
        private bool isFriendly;
        private Vector2 position;
        public bool IsFriendly => isFriendly;
        private Facing facing;
        private float timer;
        private bool flipped;
        private int xPos, yPos;
        private int velocity;

        public Boomerang(Facing facing, Vector2 position, bool isFriendly = true)
        {
            this.facing = facing;
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateBoomerangSprite(this.facing);
            this.isFriendly = isFriendly;
            velocity = 200;
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
            flipped = timer > 1000;



            switch (this.facing)
            {
                case Facing.Up:
                    yPos = flipped ? 1 : -1;
                    break;
                case Facing.Down:
                    yPos = flipped ? -1 : 1;
                    break;
                case Facing.Left:
                    xPos = flipped ? 1 : -1;
                    break;
                case Facing.Right:
                    xPos = flipped ? -1 : 1;
                    break;
                default:
                    break;
            }

            this.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * xPos * velocity);
            this.position.Y += (float)(gameTime.ElapsedGameTime.TotalSeconds * yPos * velocity);

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
