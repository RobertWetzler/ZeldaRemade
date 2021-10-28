using Project.Projectiles;

namespace Project.Collision.CollisionHandlers
{
    class ProjectilePlayerCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable projectileCollidable, ICollidable enemy, CollisionSide side)
        {
            IProjectile projectile = projectileCollidable as IProjectile;
            if (!projectile.IsFriendly)
            {
                projectile.Despawn();
            }
        }
    }
}
