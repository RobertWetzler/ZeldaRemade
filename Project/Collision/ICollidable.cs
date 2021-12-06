using Microsoft.Xna.Framework;

namespace Project.Collision
{
    public enum CollisionType
    {
        Block,
        Enemy,
        Bat,
        Item,
        NPC,
        Player,
        Projectile,
        MovableBlock,
        StairBlock,
        BlueBlock,
        BrickBlock,
        BlackBlock,
        Bomb,
        Door
    }
    public interface ICollidable
    {
        public Rectangle BoundingBox { get; }
        public CollisionType CollisionType { get; }
    }
}
