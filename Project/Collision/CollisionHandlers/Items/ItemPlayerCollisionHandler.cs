namespace Project.Collision.CollisionHandlers
{
    public class ItemPlayerCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable itemCollidable, ICollidable player, CollisionSide side)
        {
            IItems item = itemCollidable as IItems;
            item.Despawn();
            IPlayer link = player as IPlayer;
            link.Inventory.AddItem(item.type);
            if(item.type == ItemType.Heart)
            {
                link.AddHealth(2);
            }
        }
    }
}
