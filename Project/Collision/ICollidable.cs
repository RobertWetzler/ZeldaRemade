using Microsoft.Xna.Framework;

namespace Project.Collision
{
    public enum CollisionType
    {
        Block,
        Enemy,
        Item,
        NPC,
        Player,
        Projectile,
        MovableBlock,
        BlueBlock,
        Bomb
    }
    public interface ICollidable
    {
        public Rectangle BoundingBox { get; }
        public CollisionType CollisionType { get; }
    }
}
