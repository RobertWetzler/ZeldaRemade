using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class PlayerDamageCommand : ICommand
    {
        private Game1 game;

        public PlayerDamageCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.TakeDamage(1);
        }
    }
}
