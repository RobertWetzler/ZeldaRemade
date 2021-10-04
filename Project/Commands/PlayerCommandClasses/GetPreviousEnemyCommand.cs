using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Commands.PlayerCommandClasses
{
    /**
     * Command to change the current enemy to previous
     * enemy
     */
    class GetPreviousEnemyCommand : ICommand
    {
        private Game1 game;
        public GetPreviousEnemyCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
