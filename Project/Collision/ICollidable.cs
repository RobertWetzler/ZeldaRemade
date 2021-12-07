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
        Bomb,
        Door,
        Darknut
    }
    public interface ICollidable
    {
        public Rectangle BoundingBox { get; }
        public CollisionType CollisionType { get; }        
    }
}
