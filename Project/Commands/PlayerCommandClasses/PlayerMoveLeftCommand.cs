namespace Project
{
    class PlayerMoveLeftCommand : ICommand
    {
        private Game1 game;

        public PlayerMoveLeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.MoveLeft();
        }
    }
}
