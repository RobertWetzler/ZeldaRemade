namespace Project
{
    class PlayerMoveRightCommand : ICommand
    {
        private Game1 game;

        public PlayerMoveRightCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.MoveRight();
        }
    }
}
