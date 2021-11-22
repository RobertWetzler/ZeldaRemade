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
            }
            else if (item.type==ItemType.HeartContainer)
            {
                link.UpdateMaxHealth(2);
            }
            else if (item.type == ItemType.Fairy)
            {
                link.Inventory.AddItem(item.type);
                link.AddHealth(link.Inventory.GetItemCount(ItemType.HeartContainer) * 2 - link.Inventory.GetItemCount(ItemType.Heart));
            }
            else
            {
                link.Inventory.AddItem(item.type);
            }

        }
    }
}
