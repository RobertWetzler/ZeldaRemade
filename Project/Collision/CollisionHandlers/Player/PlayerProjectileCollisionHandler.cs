using Project.Projectiles;
using Project.Utilities;

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
                if (!GameOptions.IsHarderVersion)
                {
                    player.TakeDamage(1);
                }
                else
                {
                    player.TakeDamage(2);
                }
            }
        }
    }
}
