using Microsoft.Xna.Framework;
using System;

namespace Project.Collision
{
    static class CollisionDetector
    {
        public static bool IsColliding(ICollidable obj1, ICollidable obj2)
        {
            return obj1.BoundingBox.Intersects(obj2.BoundingBox);
        }

        public static CollisionSide GetCollisionSide(ICollidable subject, ICollidable target)
        {
            Rectangle subjectRect = subject.BoundingBox;
            Rectangle targetRect = target.BoundingBox;
            float dx = subjectRect.Center.X - targetRect.Center.X;
            float dy = subjectRect.Center.Y - targetRect.Center.Y;
            CollisionSide xSide = dx > 0 ? CollisionSide.Left : CollisionSide.Right;
            CollisionSide ySide = dy > 0 ? CollisionSide.Up : CollisionSide.Down;
            float xGap = Math.Abs(dx) - (subjectRect.Width / 2) - (targetRect.Width / 2);
            float yGap = Math.Abs(dy) - (subjectRect.Height / 2) - (targetRect.Height / 2);
            float xOverlap = Math.Max(0, -xGap);
            float yOverlap = Math.Max(0, -yGap);
            // Choose the direction of the smaller overlap.
            return yOverlap > xOverlap ? xSide : ySide;

        }

    }
}
