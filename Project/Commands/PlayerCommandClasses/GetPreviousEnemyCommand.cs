namespace Project
{
    /**
     * Command to change the current enemy to previous
     * enemy
     */
    class GetPreviousEnemyCommand : ICommand
    {
        private Game1 game;
        public GetPreviousEnemyCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.CurrentNPCIndex--;
            if (game.CurrentNPCIndex < 0)
            {
                game.CurrentNPCIndex = game.NPCSListLength - 1;
            }
        }
    }
}
