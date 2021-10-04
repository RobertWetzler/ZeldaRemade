using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class PlayerUseBombCommand : ICommand
    {
        private Game1 game;

        public PlayerUseBombCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.UseItem();
        }
    }
}
