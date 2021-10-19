using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision
{
    static class DetectCollision
    {
        public static bool IsColliding(ICollidable obj1, ICollidable obj2)
        {
            return obj1.BoundingBox.Intersects(obj2.BoundingBox);
        }
    }
}
