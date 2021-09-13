using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class ExitCommand : ICommand
    {
        private Game1 game;

        public ExitCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
