using System;
using System.Collections.Generic;

namespace Project.Collision
{
    public enum CollisionSide
    {
        Left,
        Up,
        Right,
        Down
    }
    public static class CollisionUtils
    {
        private static HashSet<Type> enemies = new HashSet<Type>
        {
            typeof(Bat)
        };
        public static CollisionSide Opposite(CollisionSide side)
        {
            switch (side)
            {
                case CollisionSide.Up:
                    return CollisionSide.Down;
                case CollisionSide.Down:
                    return CollisionSide.Up;
                case CollisionSide.Left:
                    return CollisionSide.Right;
                case CollisionSide.Right:
                    return CollisionSide.Left;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
