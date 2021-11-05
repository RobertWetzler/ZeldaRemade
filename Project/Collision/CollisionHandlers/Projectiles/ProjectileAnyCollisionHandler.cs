using Project.Projectiles;

namespace Project.Collision.CollisionHandlers
{
    class ProjectileAnyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable projectileCollidable, ICollidable any, CollisionSide side)
        {
            IProjectile projectile = projectileCollidable as IProjectile;
            projectile.Despawn();
        }
    }
}
