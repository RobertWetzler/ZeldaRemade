using Project.Projectiles;
using Project.Rooms.Doors;
using Project.Utilities;

namespace Project.Collision.CollisionHandlers.Doors
{
    class DoorBombCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable doorCollidable, ICollidable bombCollidable, CollisionSide side)
        {
            IDoor door = doorCollidable as IDoor;
            Bomb bomb = bombCollidable as Bomb;
            if (door.DoorType == DoorType.BOMB_CLOSED && bomb.IsExploding)
            {
                door.OpenWithBomb();
            }
        }
    }
}
