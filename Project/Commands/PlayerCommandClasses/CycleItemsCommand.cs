using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class CycleItemsCommand : ICommand
    {
        private Game1 game;

        public CycleItemsCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetSprite();   // need to implement - Cycle list of item sprites (fixed animated).
        }
    }
}
