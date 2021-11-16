using Project.Blocks.MovableBlock;

namespace Project.Collision.CollisionHandlers.Enemies
{
    class EnemyMovableBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable enemy, ICollidable blockCollidable, CollisionSide side)
        {
            MovableBlock block = blockCollidable as MovableBlock;

            (new EnemyBlockCollisionHandler()).HandleCollision(enemy, blockCollidable, side);

        }
    }
}