namespace Project
{
    class GetNextBlockCommand : ICommand
    {
        private Game1 game;
        public GetNextBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.CurrentBlockSpriteIndex++;
            if (game.CurrentBlockSpriteIndex > game.BlocksListLength - 1)
            {
                game.CurrentBlockSpriteIndex = 0;
            }
        }
    }
}
