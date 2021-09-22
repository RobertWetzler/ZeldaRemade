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
            //TODO: need to implement - Cycle list of enemis sprites (moving animated).
            //game.SetSprite();
        }
    }
}
