using Project.Projectiles;

namespace Project.Collision.CollisionHandlers.Enemies
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable enemyCollidable, ICollidable projectileCollidable, CollisionSide side)
        {
            IEnemy enemy = enemyCollidable as IEnemy;
            IProjectile projectile = projectileCollidable as IProjectile;
            if (projectile.IsFriendly)
            {
                if (!(enemy is Trap))
                {
                    enemy.Despawn();
                }
                
            }
        }
    }
}
