using Project.GameState;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Project.Commands
{
    class GetAItemCommand : ICommand
    {
        private Game1 game;
        public GetAItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if(Game1.Instance.Player.Inventory.BItem != Game1.Instance.getItem)
            Game1.Instance.Player.Inventory.SetAItem(Game1.Instance.getItem);
        }
    }
}
