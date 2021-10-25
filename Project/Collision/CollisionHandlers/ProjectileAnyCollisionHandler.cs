using Project.Projectiles;
using Project.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Text;

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
