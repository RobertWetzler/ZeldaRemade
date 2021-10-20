using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision
{
    //side that current object is colliding upon
    public enum CollisionSide
    {
        Top,
        Bottom,
        Left,
        Right
    }
    static class CollisionDetector
    {
        public static bool IsColliding(ICollidable obj1, ICollidable obj2)
        {
            return obj1.BoundingBox.Intersects(obj2.BoundingBox);
        }

        public static CollisionSide GetCollisionSide(Rectangle subject, Rectangle target)
        {
            float dx = subject.Center.X - target.Center.X;
            float dy = subject.Center.Y - target.Center.Y;
            CollisionSide xSide = dx > 0 ? CollisionSide.Left : CollisionSide.Right;
            CollisionSide ySide = dy > 0 ? CollisionSide.Top : CollisionSide.Bottom;
            float xGap = Math.Abs(dx) - (subject.Width / 2) - (target.Width / 2);
            float yGap = Math.Abs(dy) - (subject.Height / 2) - (target.Height / 2);
            float xOverlap = Math.Max(0, -xGap);
            float yOverlap = Math.Max(0, -yGap);
            // Choose the direction of the smaller overlap.
            return yOverlap > xOverlap ? xSide : ySide;

        }

    }
}
