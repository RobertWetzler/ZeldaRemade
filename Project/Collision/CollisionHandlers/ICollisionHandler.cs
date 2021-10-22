using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    public interface ICollisionHandler
    {
        public void HandleCollision(ICollidable subject, ICollidable target, CollisionSide side);
    }
}
