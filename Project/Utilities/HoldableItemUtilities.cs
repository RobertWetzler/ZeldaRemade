using Microsoft.Xna.Framework;
using Project.Entities;
using Project.Items;
using System;
using System.Collections.Generic;

namespace Project.Utilities
{
    public static class HoldableItemUtilities
    {
        public static List<ItemType> holdableItems = new List<ItemType>() { ItemType.Sword, ItemType.Bow, ItemType.Blue_Candle, ItemType.Boomerang, ItemType.Blue_Boomerang };
        public static IItems GetHoldableItem(ItemType itemType, Vector2 pos)
        {
            return itemType switch
            {
                ItemType.Bow => new Bow(pos),
                ItemType.Sword => new SwordItem(pos),
                ItemType.Blue_Candle => new BlueCandle(pos),
                ItemType.Boomerang => new BoomerangItem(pos),
                ItemType.Blue_Boomerang => new BlueBoomerangItem(pos),
                ItemType.Null => null,
                _ => throw new NotImplementedException()
            };
        }
        public static WeaponTypes GetWeaponType(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.Bow => WeaponTypes.Arrow,
                ItemType.Sword => WeaponTypes.Sword,
                ItemType.Blue_Candle => WeaponTypes.Flame,
                ItemType.Boomerang => WeaponTypes.Boomerang,
                ItemType.Blue_Boomerang => WeaponTypes.BlueBoomerang,
                _ => throw new NotImplementedException()
            };
        }
    }
}
