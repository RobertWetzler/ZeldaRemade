using Project.Rooms;
using Project.Utilities;

namespace Project.Collision.CollisionHandlers
{
    class PlayerEnemyCollisionHandler : ICollisionHandler
    {

        public void HandleCollision(ICollidable playerCollidable, ICollidable enemyCollidable, CollisionSide side)
        {
            IPlayer player = playerCollidable as IPlayer;
            if (enemyCollidable is WallMaster)
            {
                Room room11 = RoomManager.GetRoom(11);
                Game1.Instance.GameStateMachine.RoomTransition(room11);
            }
            else if (!GameOptions.IsHarderVersion)
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
