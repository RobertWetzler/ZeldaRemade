using Project.Utilities;

namespace Project.Commands
{
    class SelectHardModeCommand : ICommand
    {
        private Game1 game;
        public SelectHardModeCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            GameOptions.IsHarderVersion = true;
        }
    }
}
