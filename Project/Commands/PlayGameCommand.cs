namespace Project.Commands
{
    class PlayGameCommand : ICommand
    {
        private Game1 game;
        public PlayGameCommand(Game1 game)
        {
            this.game = game;

        }
        public void Execute()
        {
            game.GameStateMachine.Play();
        }
    }
}
