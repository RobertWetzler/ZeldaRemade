using Project.Projectiles;
using Project.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.HUD
{
    class PlayerInventory
    {
        private Dictionary<ItemType, int> inventory;

        private void InitializeInventory()
        {
            inventory.Add(ItemType.Bomb, 10);
            inventory.Add(ItemType.Key, 0);
            inventory.Add(ItemType.Rupee, 0);
            inventory.Add(ItemType.Sword, 1);
            inventory.Add(ItemType.Arrow, 10);
            inventory.Add(ItemType.Blue_Arrow, 10);
            inventory.Add(ItemType.Bow, 0);
            inventory.Add(ItemType.Blue_Candle, 1);
            inventory.Add(ItemType.Boomerang, 1);
            inventory.Add(ItemType.Blue_Boomerang, 1);
            inventory.Add(ItemType.Heart, 3);
        }
        public PlayerInventory()
        {
            inventory = new Dictionary<ItemType, int>();
            InitializeInventory();
        }

        public void AddItem(ItemType item)
        {
            inventory[item]++;
        }

        public void RemoveItem(ItemType item)
        {
            inventory[item]--;
        }
        public int GetItemCount(ItemType item)
        {
            return inventory[item];
        }
    }

    public enum ItemType
    {
        Bomb,
        Key,
        Rupee,
        Sword,
        Arrow,
        Blue_Arrow,
        Bow,
        Blue_Candle,
        Boomerang,
        Blue_Boomerang,
        Heart
    }
}
