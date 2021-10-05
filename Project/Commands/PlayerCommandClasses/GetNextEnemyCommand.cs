namespace Project
{
    /**
     * Command to change current enemy to the
     * next enemy
     */
    class GetNextEnemyCommand : ICommand
    {
        private Game1 game;

        public GetNextEnemyCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CurrentNPCIndex++;
            if (game.CurrentNPCIndex > game.NPCSListLength - 1)
            {
                game.CurrentNPCIndex = 0;
            }
        }
    }
}
