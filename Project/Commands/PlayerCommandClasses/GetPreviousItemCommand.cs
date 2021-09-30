using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class GetPreviousItemCommand : ICommand
    {
        private Game1 game;
        public GetPreviousItemCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CurrentItemSpriteIndex--;

            if (game.CurrentItemSpriteIndex < 0)
            {
                game.CurrentItemSpriteIndex = 23;
            }
        }
    }
}
