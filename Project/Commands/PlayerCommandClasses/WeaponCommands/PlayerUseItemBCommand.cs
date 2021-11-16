using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Commands.PlayerCommandClasses.WeaponCommands
{
    class PlayerUseItemBCommand: ICommand
    {
        public void Execute()
        {
            ItemType item = Game1.Instance.Player.Inventory.BItem;
            if (item != ItemType.Null)
            {
                bool canUseArrow = Game1.Instance.Player.Inventory.GetItemCount(ItemType.Arrow) > 0 ||
                    Game1.Instance.Player.Inventory.GetItemCount(ItemType.Blue_Arrow) > 0;
                if ((item == ItemType.Bow && canUseArrow) || item != ItemType.Bow)
                {
                    Game1.Instance.Player.UseWeapon(HoldableItemUtilities.GetWeaponType(item));
                }
            }
        }
    }
}
