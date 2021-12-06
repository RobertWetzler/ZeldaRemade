using Project.Utilities;

namespace Project.Collision.CollisionHandlers
{
    class PlayerEnemyCollisionHandler : ICollisionHandler
    {
      
        public void HandleCollision(ICollidable playerCollidable, ICollidable enemy, CollisionSide side)
        {
            IPlayer player = playerCollidable as IPlayer;
            if (!GameOptions.IsHarderVersion)
            {
                player.TakeDamage(1); //TODO: use a damage variable from enemy
            }
            else
            {
                player.TakeDamage(2);
            }
        }
    }
}
