namespace Project
{
    class GetPreviousItemCommand : ICommand
    {
        private Game1 game;
        public GetPreviousItemCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CurrentItemIndex--;

            if (game.CurrentItemIndex < 0)
            {
                game.CurrentItemIndex = game.ItemsListLength - 1;
            }
        }
    }
}
