using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class QuitCommand : ICommand
    {
        private Game1 game;

        public QuitCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
