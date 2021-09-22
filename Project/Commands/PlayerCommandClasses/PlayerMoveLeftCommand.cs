using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class PlayerMoveLeftCommand : ICommand
    {
        private Game1 game;

        public PlayerMoveLeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // need to implement
        }
    }
}
