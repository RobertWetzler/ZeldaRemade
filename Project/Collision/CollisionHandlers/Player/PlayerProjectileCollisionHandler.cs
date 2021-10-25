using Project.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    class PlayerProjectileCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable playerCollidable, ICollidable projectileCollidable, CollisionSide side)
        {
            IPlayer player = playerCollidable as IPlayer;
            IProjectile projectile = projectileCollidable as IProjectile;
            if (!projectile.IsFriendly)
            {
                player.TakeDamage(1);
            }
        }
    }
}
