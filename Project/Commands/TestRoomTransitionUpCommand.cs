namespace Project.Commands
{
    class TestRoomTransitionUpCommand : ICommand
    {
        public Game1 game;
        public TestRoomTransitionUpCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.GameStateMachine.RoomTransition(GameState.Direction.Up);
        }
    }
}
