using Project.Sound;

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
            if (item.type == ItemType.Heart)
            {
                link.AddHealth(2);
                SoundManager.Instance.CreateHeartSound();
            }

            if (item.type ==ItemType.HeartContainer)
            {
                link.MaxHealth();
                SoundManager.Instance.CreateItemSound();
            }
            if (item.type == ItemType.Rupee)
            {
                SoundManager.Instance.CreateRupeeSound();
            }
            if (item.type == ItemType.Key)
            {
                SoundManager.Instance.CreateKeySound();
            }
            if (item.type == ItemType.Bow)
            {
                SoundManager.Instance.CreateFanfare();
            }
            if (item.type == ItemType.Triforce)
            {
                //SoundManager.Instance.CreateVictorySound();
            }
            if (item.type == ItemType.Fairy)
            {
                SoundManager.Instance.CreateItemSound();
            }
            if (item.type == ItemType.Map)
            {
                SoundManager.Instance.CreateItemSound();
            }
            if (item.type == ItemType.Map)
            {
                SoundManager.Instance.CreateItemSound();
            }
        }
    }
}
