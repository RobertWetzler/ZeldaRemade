using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class PlayerMoveUpCommand : ICommand
    {
        private Game1 game;

        public PlayerMoveUpCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.MoveUp();
        }
    }
}
