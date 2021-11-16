using Project.GameState;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Project.Commands
{
    class GetBItemCommand : ICommand
    {
        private Game1 game;
        public GetBItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if(Game1.Instance.Player.Inventory.AItem != Game1.Instance.getItem)
            Game1.Instance.Player.Inventory.SetBItem(Game1.Instance.getItem);
        }
    }
}