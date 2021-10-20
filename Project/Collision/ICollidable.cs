using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision
{
    public interface ICollidable
    {
        public Rectangle BoundingBox { get; }
    }
}
