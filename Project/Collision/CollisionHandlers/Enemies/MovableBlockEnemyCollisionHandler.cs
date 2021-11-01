using Microsoft.Xna.Framework;
using Project.Blocks.MovableBlock;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers.Enemies
{
    class MovableBlockEnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable blockCollidable, ICollidable enemy, CollisionSide side)
        {
            MovableBlock block = blockCollidable as MovableBlock;
        

            if (block.IsMovable)
            {
                (new EnemyBlockCollisionHandler()).HandleCollision(enemy, blockCollidable, CollisionUtils.Opposite(side));
            }
            else
            {
                (new EnemyBlockCollisionHandler()).HandleCollision(enemy, blockCollidable, CollisionUtils.Opposite(side));
            }
        }
    }
}
