using Project.Utilities;

namespace Project.Commands
{
    class SelectEasyModeCommand : ICommand
    {
        private Game1 game;
        public SelectEasyModeCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            GameOptions.IsHarderVersion = false;

        }

    }
}
