using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Sprites.ItemSprites;
using System;

namespace Project.Projectiles
{
    class SwordBeam: IProjectile
    {

        private IProjectileSprite sprite;
        private IProjectile projectile;
        public bool IsFinished => sprite.IsFinished() || !IsActive;
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        private Vector2 position;
        private Facing facing;
        private int xPos, yPos;
        private int velocity;
       
        public SwordBeam(Facing facing, Vector2 position, bool isFriendly = true)
        {
            this.facing = facing;
            this.position = position;
            this.isFriendly = isFriendly;

            sprite = ItemSpriteFactory.Instance.CreateSwordSprite(this.facing);
            

            velocity = 500;

        }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public bool IsActive { get; set; } = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
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
        }
    }
}
