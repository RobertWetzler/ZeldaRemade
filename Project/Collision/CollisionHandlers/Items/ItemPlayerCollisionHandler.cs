namespace Project.Collision.CollisionHandlers
{
    public class ItemPlayerCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable itemCollidable, ICollidable player, CollisionSide side)
        {
            IItems item = itemCollidable as IItems;
            item.Despawn();
            IPlayer link = player as IPlayer;
            
            if (item.type == ItemType.Heart)
            {
                link.AddHealth(2);
                link.Inventory.AddNItems(item.type, 2);
            }
            else
            {
                link.Inventory.AddItem(item.type);
            }

            if (item.type==ItemType.HeartContainer)
            {
                link.UpdateMaxHealth(2);
            }
        }
    }
}
