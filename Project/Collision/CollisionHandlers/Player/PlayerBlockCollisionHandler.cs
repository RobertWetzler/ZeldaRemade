using Microsoft.Xna.Framework;

namespace Project.Collision.CollisionHandlers
{
    class PlayerBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable playerCollidable, ICollidable block, CollisionSide side)
        {
            IPlayer player = playerCollidable as IPlayer;


            int dx = 0;
            int dy = 0;
            switch (side)
            {
                case CollisionSide.Up:
                    //Collided with top, move down
                    dy = block.BoundingBox.Bottom - player.BoundingBox.Top;
                    break;
                case CollisionSide.Down:
                    //Collided with bottom, move up
                    dy = block.BoundingBox.Top - player.BoundingBox.Bottom;
                    break;
                case CollisionSide.Left:
                    dx = block.BoundingBox.Right - player.BoundingBox.Left;
                    break;
                case CollisionSide.Right:
                    dx = block.BoundingBox.Left - player.BoundingBox.Right;
                    break;
            }
            player.Position = new Vector2(player.Position.X + dx, player.Position.Y + dy);
        }
    }
}
