using System;

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
                link.Inventory.AddNItems(ItemType.Heart, Math.Min(2, link.Health.MaxHealth - link.Health.CurrentHealth));
                link.Health.AddHealth(2);
            }
            else if (item.type == ItemType.HeartContainer)
            {
                link.Inventory.AddNItems(ItemType.Heart, 2);
                link.Inventory.AddItem(ItemType.HeartContainer);
                link.Health.UpdateMaxHealth(2);
            }
            else if (item.type == ItemType.Fairy)
            {
                int value = link.Inventory.GetItemCount(ItemType.HeartContainer) * 2 - link.Inventory.GetItemCount(ItemType.Heart);
                link.Inventory.AddItem(item.type);
                link.Inventory.AddNItems(ItemType.Heart, Math.Min(value, link.Health.MaxHealth - link.Health.CurrentHealth));
                link.Health.AddHealth(value);
            }
            else
            {
                link.Inventory.AddItem(item.type);
            }

        }
    }
}
