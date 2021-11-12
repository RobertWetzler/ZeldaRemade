using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Commands
{
    class PauseGameCommand: ICommand
    {
        private Game1 game;
        public PauseGameCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.GameStateMachine.Pause();
        }
    }
}
