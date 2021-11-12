using Microsoft.Xna.Framework;
using Project.Blocks.MovableBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers.Enemies
{
    class EnemyMovableBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable enemy, ICollidable blockCollidable, CollisionSide side)
        {
            MovableBlock block = blockCollidable as MovableBlock;

            (new EnemyBlockCollisionHandler()).HandleCollision(enemy, blockCollidable, CollisionUtils.Opposite(side));

        }
    }
}