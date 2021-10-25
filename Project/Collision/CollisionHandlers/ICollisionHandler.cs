using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    public interface ICollisionHandler
    {
        /* Interface for all collision handlers.
         * Collidee is the object that the handler is operating upon.
         * Collider is the object colliding with collidee.
         * Side is the side of the collidee that the collider is colliding upon.
         */
        public void HandleCollision(ICollidable collidee, ICollidable collider, CollisionSide side);
    }
}
