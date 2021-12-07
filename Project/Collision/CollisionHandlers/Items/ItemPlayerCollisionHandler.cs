using Microsoft.Xna.Framework;
using Project.Items;
using Project.Sound;
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
                SoundManager.Instance.CreateHeartSound();
            }
            else if (item.type == ItemType.HeartContainer)
            {
                link.Inventory.AddNItems(ItemType.Heart, 2);
                link.Inventory.AddItem(ItemType.HeartContainer);
                link.Health.UpdateMaxHealth(2);
                SoundManager.Instance.CreateHeartSound();
            }
            else if (item.type == ItemType.Fairy)
            {
                int value = link.Inventory.GetItemCount(ItemType.HeartContainer) * 2 - link.Inventory.GetItemCount(ItemType.Heart);
                link.Inventory.AddItem(item.type);
                link.Inventory.AddNItems(ItemType.Heart, Math.Min(value, link.Health.MaxHealth - link.Health.CurrentHealth));
                link.Health.AddHealth(value);
                SoundManager.Instance.CreateMagicalSound();
            }
            else if (item.type == ItemType.Triforce)
            {
                link.Inventory.AddItem(item.type);
                item = new Triforce(new Vector2(link.Position.X - 20, link.Position.Y - 50));
                Game1.Instance.GameStateMachine.PickUpItemScreen(item);
                SoundManager.Instance.CreateVictorySound();
            }
            else if (item.type == ItemType.Bow)
            {
                link.Inventory.AddItem(item.type);
                item = new Bow(new Vector2(link.Position.X - 20, link.Position.Y - 50));
                Game1.Instance.GameStateMachine.PickUpItemScreen(item);
                SoundManager.Instance.CreateFanfare();
            }
            else if (item.type == ItemType.Boomerang)
            {
                link.Inventory.AddItem(item.type);
                SoundManager.Instance.CreateFanfare();
            }
            else if (item.type == ItemType.Rupee)
            {
                link.Inventory.AddItem(item.type);
                SoundManager.Instance.CreateRupeeSound();
            }
            else if (item.type == ItemType.Key)
            {
                link.Inventory.AddItem(item.type);
                SoundManager.Instance.CreateKeySound();
            }
            else if (item.type == ItemType.Bomb)
            {
                link.Inventory.AddItem(item.type);
                SoundManager.Instance.CreateItemSound();
            }
            else if (item.type == ItemType.Map)
            {
                link.Inventory.AddItem(item.type);
                SoundManager.Instance.CreateItemSound();
            }
            else if (item.type == ItemType.Compass)
            {
                link.Inventory.AddItem(item.type);
                SoundManager.Instance.CreateItemSound();
            }


        }
    }
}
