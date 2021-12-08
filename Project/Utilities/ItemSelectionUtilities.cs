using Microsoft.Xna.Framework;
using Project.Entities;
using Project.Items;
using System;
using System.Collections.Generic;

namespace Project.Utilities
{
    public static class ItemSelectionUtilities
    {
        private static Bow bow = new Bow(new Vector2(700, 180));
        private static SwordItem sword = new SwordItem(new Vector2(700, 180));
        private static BlueCandle blueCandle = new BlueCandle(new Vector2(600, 180));
        private static BoomerangItem boomerang = new BoomerangItem(new Vector2(800, 180));
        private static BlueBoomerangItem blueBoomerang = new BlueBoomerangItem(new Vector2(500, 180));
        private static Map map = new Map(new Vector2(165, 440));
        private static Compass compass = new Compass(new Vector2(165, 600));
        private static BombItem bomb = new BombItem(new Vector2(600, 250));

        private static IItems GetInventoryItem(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.Bow => bow,
                ItemType.Sword => sword,
                ItemType.Blue_Candle => blueCandle,
                ItemType.Boomerang => boomerang,
                ItemType.Blue_Boomerang => blueBoomerang,
                ItemType.Map => map,
                ItemType.Compass => compass,
                ItemType.Bomb => bomb,
                ItemType.Null => null,
                //_ => throw new NotImplementedException()
            };
        }

        public static IItems GetSelectedItem(ItemType itemType, Vector2 pos)
        {
            return itemType switch
            {
                ItemType.Bow => new Bow(pos),
                ItemType.Sword => new SwordItem(pos),
                ItemType.Blue_Candle => new BlueCandle(pos),
                ItemType.Boomerang => new BoomerangItem(pos),
                ItemType.Blue_Boomerang => new BlueBoomerangItem(pos),
                ItemType.Bomb => new BombItem(pos),
                ItemType.Null => null,
                _ => throw new NotImplementedException()
            };
        }

        public static Dictionary<int, ItemType> IdToItem = new Dictionary<int, ItemType>();
        public static List<IItems> InventoryItems = new List<IItems>();

        public static void LoadAllEquipableItems()
        {
            IdToItem = new Dictionary<int, ItemType>();

            IdToItem.Add(0, ItemType.Blue_Boomerang);
            IdToItem.Add(1, ItemType.Blue_Candle);
            IdToItem.Add(2, ItemType.Bow);
            IdToItem.Add(3, ItemType.Boomerang);
            IdToItem.Add(4, ItemType.Sword);
            IdToItem.Add(5, ItemType.Bomb);
            IdToItem.Add(8, ItemType.Null);
            IdToItem.Add(6, ItemType.Null);
            IdToItem.Add(7, ItemType.Null);

        }

        public static void UpdateAllInventoryItems()
        {
            foreach (ItemType holdableItem in HoldableItemUtilities.holdableItems)
            {
                if (Game1.Instance.Player.Inventory.GetItemCount(holdableItem) > 0)
                {
                    InventoryItems.Add(ItemSelectionUtilities.GetInventoryItem(holdableItem));
                }
                else if(Game1.Instance.Player.Inventory.GetItemCount(holdableItem) <= 0)
                {

                    InventoryItems.RemoveAll(obj => obj.Equals(ItemSelectionUtilities.GetInventoryItem(holdableItem)));
                    //InventoryItems.Clear();
                    //InventoryItems.Remove(ItemSelectionUtilities.GetInventoryItem(holdableItem));
                    //InventoryItems.Remove(ItemSelectionUtilities.GetInventoryItem(ItemType.Map));
                }
            }
        }
    }
}
