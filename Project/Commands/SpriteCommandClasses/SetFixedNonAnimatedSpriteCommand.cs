using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class SetFixedNonAnimatedSpriteCommand : ICommand
    {
        private Game1 game;

        public SetFixedNonAnimatedSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetSprite(new FixedNonAnimatedSprite());
        }
    }
}
