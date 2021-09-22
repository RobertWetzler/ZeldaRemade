using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class SetFixedAnimatedSpriteCommand : ICommand
    {
        private Game1 game;

        public SetFixedAnimatedSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetSprite(new FixedAnimatedSprite());
        }
    }
}
