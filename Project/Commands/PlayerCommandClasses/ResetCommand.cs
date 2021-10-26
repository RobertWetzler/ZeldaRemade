using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class ResetCommand : ICommand
    {
        private Game1 game;

        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            //TODO: Reset Player after death
        }
    }
}
