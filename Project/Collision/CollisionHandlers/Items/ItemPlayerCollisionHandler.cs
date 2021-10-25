using System;
using Project;


namespace Project.Collision.CollisionHandlers
{
    public class ItemPlayerCollisionHandler : ICollisionHandler
    {
            public void HandleCollision(ICollidable itemCollidable, ICollidable player, CollisionSide side)
            {
                IItems item = itemCollidable as IItems;
                item.Despawn();
            }
    }
}
