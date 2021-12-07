using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Shading;
using Project.Sound;
using Project.Sprites.ItemSprites;
using System;

namespace Project.Projectiles
{
    class Bomb : FireLight, IProjectile
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
            this.isFriendly = isFriendly;
            offsetVal = 30f;
            offset = Offset();
            SoundManager.Instance.CreateBombDropSound();
            lightColor = Color.Orange;
            lightScale = 2f;
            lightIntensity = 1f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position + offset);
        }

        public void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle(sprite.DestRectangle.X, sprite.DestRectangle.Y, sprite.DestRectangle.Width, sprite.DestRectangle.Height);
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            lightOffset = new Vector2(0, -BoundingBox.Height / 3);
            if (IsExploding)
            {
                lightOffset = Vector2.Zero;
                lightColor = Color.Red;
                lightScale = 3f;
                innerLightScale = 2.3f;
            }
            sprite.Update(gameTime);
            if (IsExploding)
            {
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
