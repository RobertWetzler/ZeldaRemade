using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    static class CollisionHandlerUtils
    {
        static Type GetCollisionType(Type type)
        {
            if(CollisionTypes.enemies.Contains(type))
            {
                return typeof(IEnemy);
            }
            return type;
        }
    }
}
