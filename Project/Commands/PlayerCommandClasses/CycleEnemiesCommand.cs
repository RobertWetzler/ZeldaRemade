using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class CycleEnemiesCommand : ICommand
    {
        private Game1 game;

        public CycleEnemisCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetSprite();   // need to implement - Cycle list of enemis sprites (moving animated).
        }
    }
}
