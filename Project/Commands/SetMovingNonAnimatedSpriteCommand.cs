using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class SetMovingNonAnimatedSpriteCommand : ICommand
    {
        private Game1 game;

        public SetMovingNonAnimatedSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetSprite(new MovingNonAnimatedSprite());
        }
    }
}
