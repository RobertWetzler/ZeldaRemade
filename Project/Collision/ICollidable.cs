using Microsoft.Xna.Framework;

namespace Project.Collision
{
    public interface ICollidable
    {
        public Rectangle BoundingBox { get; }
    }
}
