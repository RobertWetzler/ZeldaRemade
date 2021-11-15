using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Commands
{
    class TestRoomTransitionLeftCommand : ICommand
    {
        public Game1 game;
        public TestRoomTransitionLeftCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            this.game.GameStateMachine.RoomTransition(GameState.Direction.Left);
        }
    }
}
