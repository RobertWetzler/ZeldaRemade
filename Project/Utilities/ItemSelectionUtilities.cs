using Microsoft.Xna.Framework;
using Project.Entities;
using Project.Items;
using System;
using System.Collections.Generic;

namespace Project.Utilities
{
    public static class ItemSelectionUtilities
    {

        public static IItems GetInventoryItem(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.Bow => new Bow(new Vector2(700, 180)),
                ItemType.Sword => new SwordItem(new Vector2(500, 250)),
                ItemType.Blue_Candle => new BlueCandle(new Vector2(600, 180)),
                ItemType.Boomerang => new BoomerangItem(new Vector2(800, 180)),
                ItemType.Blue_Boomerang => new BlueBoomerangItem(new Vector2(500, 180)),
                ItemType.Map => new Map(new Vector2(165, 440)),
                ItemType.Compass => new Compass(new Vector2(165, 600)),
                ItemType.Bomb => new BombItem(new Vector2(600,250)),
                ItemType.Null => null,
                _ => throw new NotImplementedException()
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
            foreach (ItemType holdableItems in HoldableItemUtilities.holdableItems)
            {
                if (Game1.Instance.Player.Inventory.GetItemCount(holdableItems) > 0)
                {
                    InventoryItems.Add(ItemSelectionUtilities.GetInventoryItem(holdableItems));
                }
                else if(ItemSelectionUtilities.GetInventoryItem(holdableItems) != null)
                {
                    InventoryItems.Remove(ItemSelectionUtilities.GetInventoryItem(holdableItems));
                }
            }
        }
    }
}
