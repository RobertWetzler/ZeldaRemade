using System;
using Project;


namespace Project.Collision.CollisionHandlers
{
    public class PlayerItemCollisionHandler : ICollisionHandler
    {
            public void HandleCollision(ICollidable itemCollidable, ICollidable any, CollisionSide side)
            {
                IItems items = itemCollidable as IItems;
                items.Despawn();
            }
    }
}
