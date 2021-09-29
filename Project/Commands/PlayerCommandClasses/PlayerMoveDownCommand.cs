using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class PlayerMoveDownCommand : ICommand
    {
        private Game1 game;

        public PlayerMoveDownCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.MoveDown();
        }
    }
}
