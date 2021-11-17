namespace Project.Commands
{
    class TestRoomTransitionRightCommand : ICommand
    {
        public Game1 game;
        public TestRoomTransitionRightCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.GameStateMachine.RoomTransition(GameState.Direction.Right);
        }
    }
}
