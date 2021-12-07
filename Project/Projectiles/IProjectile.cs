using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;

namespace Project.Projectiles
{
    public interface IProjectile : ICollidable
    {
        public bool IsActive { get; set; }
        public bool IsFriendly { get; }
        public bool IsFinished { get; }
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
        public void Despawn()
        {
            IsActive = false;
            RoomManager.Instance.CurrentRoom.RemoveProjectile(this);
        }
        public bool IsInBounds()
        {
            if (BoundingBox == Rectangle.Empty)
            {
                return true;
            }
            bool inBounds = Game1.Instance.PlayerBounds.Contains(BoundingBox.Left, BoundingBox.Top);
            inBounds = inBounds && Game1.Instance.PlayerBounds.Contains(BoundingBox.Left, BoundingBox.Bottom);
            inBounds = inBounds && Game1.Instance.PlayerBounds.Contains(BoundingBox.Right, BoundingBox.Top);
            inBounds = inBounds && Game1.Instance.PlayerBounds.Contains(BoundingBox.Right, BoundingBox.Bottom);
            return inBounds;
        }
    }
}
