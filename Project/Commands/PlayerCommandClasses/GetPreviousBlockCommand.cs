namespace Project
{
    class GetPreviousBlockCommand : ICommand
    {
        private Game1 game;
        public GetPreviousBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.CurrentBlockSpriteIndex--;
            if (game.CurrentBlockSpriteIndex < 0)
            {
                game.CurrentBlockSpriteIndex = game.BlocksListLength - 1;
            }
        }
    }
}
