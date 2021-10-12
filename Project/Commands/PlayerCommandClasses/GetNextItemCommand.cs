namespace Project
{
    class GetNextItemCommand : ICommand
    {
        private Game1 game;
        public GetNextItemCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CurrentItemIndex++;

            if (game.CurrentItemIndex > game.ItemsListLength - 1)
            {
                game.CurrentItemIndex = 0;
            }
        }
    }
}
