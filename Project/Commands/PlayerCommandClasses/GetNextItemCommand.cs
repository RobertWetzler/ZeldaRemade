using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class GetNextItemCommand : ICommand
    {
        private Game1 game;
        public GetNextItemCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CurrentItemSpriteIndex++;

            if(game.CurrentItemSpriteIndex > 25)
            {
                game.CurrentItemSpriteIndex = 0;
            }
        }
    }
}
