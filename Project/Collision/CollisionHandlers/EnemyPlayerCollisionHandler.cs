using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    class EnemyWeaponCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable weapon, ICollidable enemyCollidable, CollisionSide side)
        {
            IEnemy enemy1 = enemyCollidable as IEnemy;
            enemy1.TakeDamage(1); //TODO: use a damage variable from enemy
        }
    }
}
