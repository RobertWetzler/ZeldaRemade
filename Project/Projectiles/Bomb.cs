using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Sound;
using Project.Sprites.ItemSprites;
using System;

namespace Project.Projectiles
{
    class Bomb : IProjectile
    {
        private IProjectileSprite sprite;
        public bool IsFinished => sprite.IsFinished() || !IsActive;
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        public bool HasExploded { get; set; } = false;
        private float timer;
        public bool IsExploding => timer > 1000 && !HasExploded;
        private Vector2 position;
        private Facing facing;
        private Vector2 offset;
        private float offsetVal;
        public Rectangle BoundingBox => boundingBox;
        private Rectangle boundingBox;
        public CollisionType CollisionType => CollisionType.Bomb;
        public bool IsActive { get; set; } = true;

        public Bomb(Facing facing, Vector2 position, bool isFriendly = true)
        {
            this.facing = facing;
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateBombSprite(this.facing);
            boundingBox = sprite.DestRectangle;
            this.isFriendly = isFriendly;
            offsetVal = 30f;
            offset = Offset();
            SoundManager.Instance.CreateBombDropSound();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position + offset);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            sprite.Update(gameTime);
            if (IsExploding)
            {
                boundingBox = new Rectangle(sprite.DestRectangle.X, sprite.DestRectangle.Y, sprite.DestRectangle.Width, sprite.DestRectangle.Height);
                boundingBox.Inflate(sprite.DestRectangle.Width, sprite.DestRectangle.Height); //double size of bounding box
            }

        }

        public Vector2 Offset()
        {

            offset = facing switch
            {
                Facing.Up => new Vector2(0f, -offsetVal),
                Facing.Down => new Vector2(0f, offsetVal),
                Facing.Right => new Vector2(offsetVal, 0f),
                Facing.Left => new Vector2(-offsetVal, 0f),
                _ => throw new NotImplementedException()
            };

            return offset;

        }
    }
}
