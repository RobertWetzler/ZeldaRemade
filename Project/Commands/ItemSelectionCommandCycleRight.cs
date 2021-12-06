namespace Project
{
    class ItemSelectionCommandCycleRight : ICommand
    {
        private Game1 game;

        public ItemSelectionCommandCycleRight(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.ItemIdx++;
            if (this.game.ItemIdx >= 8)
                this.game.ItemIdx = 0;

        }
    }
}
