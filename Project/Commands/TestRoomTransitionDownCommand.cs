using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Commands
{
    class TestRoomTransitionDownCommand : ICommand
    {
        public Game1 game;
        public TestRoomTransitionDownCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.GameStateMachine.RoomTransition(GameState.Direction.Down);
        }
    }
}
