using Project.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers.Enemies
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable enemyCollidable, ICollidable projectileCollidable, CollisionSide side)
        {
            IEnemy enemy = enemyCollidable as IEnemy;
            IProjectile projectile = projectileCollidable as IProjectile;
            if(projectile.IsFriendly)
            {
                enemy.Despawn();
            }
        }
    }
}
