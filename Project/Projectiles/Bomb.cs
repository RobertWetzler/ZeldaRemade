using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Collision;
using Project.Sprites.ItemSprites;

namespace Project.Projectiles
{
    class Bomb : IProjectile
    {

        private IWeaponSprite sprite;
        public bool IsFinished => sprite.isFinished() || !IsActive;
        private bool isFriendly;
        public bool IsFriendly => isFriendly;
        public bool IsExploding => timer > 3000;
        private float timer;
        
        public Bomb(Facing facing, Vector2 position, bool isFriendly = true)
        {
            sprite = ItemSpriteFactory.Instance.CreateBombSprite(facing, position);
            this.isFriendly = isFriendly;
            SoundFactory.Instance.CreateBombDrop();
        }

        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Bomb;
        public bool IsActive { get; set; } = true;
        

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            sprite.Update(gameTime);
        }
    }
}
