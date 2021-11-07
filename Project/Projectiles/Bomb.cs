using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
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
        private Vector2 position;
        private Facing facing;
        private Vector2 offset;
        private float offsetVal;
        public Bomb(Facing facing, Vector2 position, bool isFriendly = true)
        {
            this.facing = facing;
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateBombSprite(this.facing);
            this.isFriendly = isFriendly;
            offsetVal = 30f;
            offset = Offset();
        }

        public Rectangle BoundingBox => sprite.DestRectangle;
        public bool IsActive { get; set; } = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position + offset);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
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
