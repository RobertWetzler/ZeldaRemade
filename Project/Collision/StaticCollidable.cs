using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision
{
    public abstract class StaticCollidable : ICollidable
    {
        public CollidableType Type => CollidableType.Static;
        public abstract Rectangle BoundingBox { get; }

        public abstract void HandleCollision(ICollidable other);
    }
}
