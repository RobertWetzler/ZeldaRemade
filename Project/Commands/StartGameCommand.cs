using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Commands
{
    class StartGameCommand : ICommand
    {
        private Game1 game;
        public StartGameCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.ShowTitleScreen = false;
        }
    }
}
