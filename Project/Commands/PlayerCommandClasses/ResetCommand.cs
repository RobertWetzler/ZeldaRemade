using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class ResetCommand : ICommand
    {
        private Game1 game;

        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            // need to implement
            game = new Game1();
            game.Run();         // ? reset all variables
        }
    }
}
