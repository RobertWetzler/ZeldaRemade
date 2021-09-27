using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class GetNextBlockCommand : ICommand
    {
        private Game1 game;
        public GetNextBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.CurrentBlockSpriteIndex++;
            if (game.CurrentBlockSpriteIndex > 9)
            {
                game.CurrentBlockSpriteIndex = 0;
            }
        }
    }
}
