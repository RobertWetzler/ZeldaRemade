

namespace Project.Collision.CollisionHandlers
{
    class PlayerEnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable playerCollidable, ICollidable enemy, CollisionSide side)
        {
            IPlayer player = playerCollidable as IPlayer;
            player.TakeDamage(1); //TODO: use a damage variable from enemy 
        }
    }
}
