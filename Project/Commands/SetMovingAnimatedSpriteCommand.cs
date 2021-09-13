using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class SetMovingAnimatedSpriteCommand : ICommand
    {
        private Game1 game;

        public SetMovingAnimatedSpriteCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetSprite(new MovingAnimatedSprite());
        }
    }
}
