using Microsoft.Xna.Framework;
using Project.Blocks.MovableBlock;

namespace Project.Collision.CollisionHandlers
{
    class MovableBlockPlayerCollisionHandler: ICollisionHandler
    {
        public void HandleCollision(ICollidable blockCollidable, ICollidable player, CollisionSide side)
        {
            MovableBlock block = blockCollidable as MovableBlock;
            if (block.IsMovable)
            {
                switch (side)
                {
                    case CollisionSide.Up:
                        block.MoveBlock(MovingDir.Down);
                        break;
                    case CollisionSide.Down:
                        block.MoveBlock(MovingDir.Up);
                        break;
                    case CollisionSide.Left:
                        block.MoveBlock(MovingDir.Right);
                        break;
                    case CollisionSide.Right:
                        block.MoveBlock(MovingDir.Left);
                        break;
                }
            }
            else
            {
                (new PlayerBlockCollisionHandler()).HandleCollision(player, blockCollidable, CollisionUtils.Opposite(side));
            }
        }
    }
}
