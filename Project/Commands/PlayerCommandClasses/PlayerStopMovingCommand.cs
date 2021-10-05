namespace Project
{
    class PlayerStopMovingCommand : ICommand
    {
        private Game1 game;

        public PlayerStopMovingCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.StopMoving();
        }
    }
}
