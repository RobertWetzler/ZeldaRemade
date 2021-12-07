namespace Project
{
    class ItemSelectionCommandCycleLeft : ICommand
    {
        private Game1 game;

        public ItemSelectionCommandCycleLeft(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {

            if (this.game.ItemIdx <= 0)
                this.game.ItemIdx = 8;
            this.game.ItemIdx--;
        }
    }
}
