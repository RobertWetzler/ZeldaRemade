using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class CycleBlocksCommand : ICommand
    {
        private Game1 game;

        public CycleBlocksCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetSprite();   // need to implement - Cycle list of block sprites (fixed nonanimated).
        }
    }
}
