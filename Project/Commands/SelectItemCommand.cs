namespace Project.Commands
{
    class SelectItemCommand : ICommand
    {
        private Game1 game;
        public SelectItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.GameStateMachine.ItemSelectionScreen();
        }
    }
}
