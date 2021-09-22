using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class CycleEnemiesCommand : ICommand
    {
        private Game1 game;

        public CycleEnemiesCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            //TODO: need to implement - Cycle list of enemis sprites (moving animated).
            //game.SetSprite(); 
        }
    }
}
