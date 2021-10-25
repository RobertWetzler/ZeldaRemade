using Project.Projectiles;
using Project.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    class ProjectileEnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable projectileCollidable, ICollidable enemy, CollisionSide side)
        {
            IProjectile projectile = projectileCollidable as IProjectile;
            if(projectile.IsFriendly)
            {
                projectile.Despawn();
            }
        }
    }
}
