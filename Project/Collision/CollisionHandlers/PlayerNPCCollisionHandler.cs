using Microsoft.Xna.Framework;

namespace Project.Collision.CollisionHandlers
{
    class PlayerNPCCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable playerCollidable, ICollidable npc, CollisionSide side)
        {
            IPlayer player = playerCollidable as IPlayer;
            int dx = 0;
            int dy = 0;
            switch (side)
            {
                case CollisionSide.Up:
                    //Collided with top, move down
                    dy = npc.BoundingBox.Bottom - player.BoundingBox.Top;
                    break;
                case CollisionSide.Down:
                    //Collided with bottom, move up
                    dy = npc.BoundingBox.Top - player.BoundingBox.Bottom;
                    break;
                case CollisionSide.Left:
                    dx = npc.BoundingBox.Right - player.BoundingBox.Left;
                    break;
                case CollisionSide.Right:
                    dx = npc.BoundingBox.Left - player.BoundingBox.Right;
                    break;
            }
            player.Position = new Vector2(player.Position.X + dx, player.Position.Y + dy);
        }
    }
}
